using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
using System.IO;

namespace Pim
{
    public static class DatabaseService
    {
        // Define o nome do arquivo do banco de dados
        private static readonly string DbFile = "SolvIT.db";

        // Define a "string de conexão"
        private static readonly string ConnectionString = $"Data Source={DbFile};Version=3;";

        // Retorna uma nova conexão com o banco
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
        public static string HashSenhaSimples(string senha)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        public static void RodarScriptDeTeste()
        {
            using (var connection = GetConnection())
            {
                // Cole o SQL gigante aqui dentro do @""
                string sql = @"
            -- 1. LIMPEZA
            DELETE FROM Historico;
            DELETE FROM Chamados;
            DELETE FROM Categorias;
            DELETE FROM Utilizadores;
            DELETE FROM sqlite_sequence WHERE name IN ('Utilizadores', 'Categorias', 'Chamados', 'Historico');

            -- 2. USUÁRIOS
            INSERT INTO Utilizadores (Id, Nome, Email, SenhaHash, Tipo, DataRegistro) VALUES 
            (1, 'Administrador Master', 'admin@solvit.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Admin', datetime('now')),
            (2, 'Carlos Técnico', 'carlos@solvit.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Atendente', datetime('now')),
            (3, 'Ana Suporte', 'ana@solvit.com',    'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Atendente', datetime('now')),
            (4, 'Bruno Cliente', 'bruno@cliente.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Solicitante', datetime('now')),
            (5, 'Fernanda RH', 'fernanda@rh.com',   'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Solicitante', datetime('now'));

            -- 3. CATEGORIAS
            INSERT INTO Categorias (Id, Nome, Descricao) VALUES
            (1, 'Hardware', 'Problemas físicos: Monitor, Teclado, Impressora'),
            (2, 'Software', 'Instalação, Office, Windows, Erros de sistema'),
            (3, 'Rede', 'Wi-Fi, Internet lenta, Queda de conexão'),
            (4, 'Acesso', 'Reset de senha, Conta bloqueada, Permissões'),
            (5, 'Outros', 'Dúvidas gerais e solicitações diversas');

            -- 4. CHAMADOS
            INSERT INTO Chamados (Titulo, Descricao, DataAbertura, Status, Prioridade, CategoriaId, UsuarioId, TecnicoId) VALUES
            ('Computador não liga', 'Aperto o botão de ligar e não acontece nada, nem bipa.', datetime('now', '-2 days'), 'Aberto', 'Alta', 1, 4, NULL);

            INSERT INTO Chamados (Titulo, Descricao, DataAbertura, Status, Prioridade, CategoriaId, UsuarioId, TecnicoId) VALUES
            ('Erro ao abrir Excel', 'Aparece uma mensagem de erro de licença quando abro as planilhas do RH.', datetime('now', '-1 days'), 'Em Andamento', 'Média', 2, 5, 2);

            INSERT INTO Chamados (Titulo, Descricao, DataAbertura, Status, Prioridade, CategoriaId, UsuarioId, TecnicoId) VALUES
            ('Internet muito lenta', 'Não consigo acessar o site do banco, demora muito.', datetime('now', '-5 days'), 'Resolvido', 'Baixa', 3, 4, 3);

            INSERT INTO Chamados (Titulo, Descricao, DataAbertura, Status, Prioridade, CategoriaId, UsuarioId, TecnicoId) VALUES
            ('Impressora travando papel', 'A impressora do corredor está atolando papel toda hora.', datetime('now', '-3 hours'), 'Aberto', 'Média', 1, 5, NULL);

            -- 5. HISTÓRICO
            INSERT INTO Historico (ChamadoId, UsuarioId, Mensagem, DataHora) VALUES
            (2, 5, 'Preciso disso urgente para fechar a folha de pagamento.', datetime('now', '-1 days', '+10 minutes'));

            INSERT INTO Historico (ChamadoId, UsuarioId, Mensagem, DataHora) VALUES
            (2, 2, 'Olá Fernanda. Vou verificar sua licença remotamente. Pode me passar o AnyDesk?', datetime('now', '-20 hours'));
        ";

                connection.Execute(sql);
            }
        }



        // Método principal de inicialização
        public static void InitDatabase()
        {
            // Cria o arquivo do banco se ele não existir
            if (!File.Exists(DbFile))
            {
                SQLiteConnection.CreateFile(DbFile);
            }

            // Abre a conexão e cria as tabelas
            using (var connection = GetConnection())
            {
                connection.Open();
                // Isso garante que o SQLite verifique os relacionamentos (FKs)
                connection.Execute("PRAGMA foreign_keys = ON;");

                // --- Tabela de Categorias ---
                // (Usamos "IF NOT EXISTS" para não dar erro se a tabela já existir)
                connection.Execute(@"
                CREATE TABLE IF NOT EXISTS Categorias (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome        TEXT NOT NULL,
                    Descricao   TEXT
                )");

                // --- Tabela de Chamados ---
                // (Vamos aproveitar e já criar a tabela de chamados,
                // pois vamos precisar dela logo)
                connection.Execute(@"
                CREATE TABLE IF NOT EXISTS Chamados (
                    Id           INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titulo       TEXT NOT NULL,
                    Descricao    TEXT,
                    DataAbertura DATETIME,
                    Status       TEXT,
                    Prioridade   TEXT,
                    CategoriaId  INTEGER,
                    UsuarioId    INTEGER,       -- Quem abriu o chamado (Solicitante)
                    TecnicoId    INTEGER,       -- Quem está atendendo (Atendente/Admin) <--- NOVO
                    AnexoPath    TEXT,          -- Caminho do arquivo anexo <--- NOVO
                    FOREIGN KEY(CategoriaId) REFERENCES Categorias(Id),
                    FOREIGN KEY(UsuarioId)   REFERENCES Utilizadores(Id),
                    FOREIGN KEY(TecnicoId)   REFERENCES Utilizadores(Id)
                )");
                connection.Execute(@"
                CREATE TABLE IF NOT EXISTS Utilizadores (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome        TEXT NOT NULL,
                    Email       TEXT NOT NULL UNIQUE,
                    SenhaHash   TEXT NOT NULL,
                    Tipo        TEXT NOT NULL,
                    DataRegistro DATETIME
                )");
                // --- Tabela de Histórico (Comentários e Logs) ---
                connection.Execute(@"
                CREATE TABLE IF NOT EXISTS Historico (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    ChamadoId   INTEGER NOT NULL,
                    UsuarioId   INTEGER NOT NULL,
                    Mensagem    TEXT NOT NULL,
                    DataHora    DATETIME,
                    FOREIGN KEY(ChamadoId) REFERENCES Chamados(Id),
                    FOREIGN KEY(UsuarioId) REFERENCES Utilizadores(Id)
                )");



                var userCount = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Utilizadores");
                if (userCount == 0)
                {
                    // ATENÇÃO: PARA UM SISTEMA REAL, USE UMA BIBLIOTECA DE HASHING SEGURA (ex: BCrypt).
                    // Aqui é apenas um placeholder para o hash.
                    string senhaAdmin = "admin123";
                    string senhaAdminHash = HashSenhaSimples(senhaAdmin); // Nosso hash simples

                }


                // --- Preencher Dados Iniciais ---
                // Verifica se a tabela de categorias está vazia
                
            }
        }
    }
}
