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
                int quantidadeUsuarios = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Utilizadores");

                if (quantidadeUsuarios > 0)
                {
                    // Se já tem gente no banco, NÃO roda o script de reset.
                    // Apenas sai do método.
                    return;
                }
                string sql = @"
            -- ====================================================
            -- 1. LIMPEZA GERAL
            -- ====================================================
            DELETE FROM Historico;
            DELETE FROM Chamados;
            DELETE FROM Categorias;
            DELETE FROM Utilizadores;
            DELETE FROM Artigos;
            
            -- Zera os contadores automáticos (IDs)
            DELETE FROM sqlite_sequence WHERE name IN ('Utilizadores', 'Categorias', 'Chamados', 'Historico', 'Artigos');

            -- ====================================================
            -- 2. USUÁRIOS (Com Telefone, Depto e Bio)
            -- Senha padrão para todos: '123'
            -- ====================================================
            INSERT INTO Utilizadores (Id, Nome, Email, SenhaHash, Tipo, DataRegistro, Telefone, Departamento, Bio) VALUES 
            (1, 'Administrador Master', 'admin@solvit.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Admin', datetime('now'), '(11) 99999-0001', 'TI Infraestrutura', 'Administrador geral do sistema.'),
            (2, 'Carlos Técnico', 'carlos@solvit.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Atendente', datetime('now'), '(11) 99999-0002', 'Suporte N2', 'Especialista em Hardware e Redes.'),
            (3, 'Ana Suporte', 'ana@solvit.com',    'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Atendente', datetime('now'), '(11) 99999-0003', 'Service Desk', 'Atendimento de primeiro nível e softwares.'),
            (4, 'Bruno Cliente', 'bruno@cliente.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Solicitante', datetime('now'), '(11) 98888-1001', 'Vendas', 'Gerente comercial.'),
            (5, 'Fernanda RH', 'fernanda@rh.com',   'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Solicitante', datetime('now'), '(11) 98888-1002', 'Recursos Humanos', 'Analista de DP.');

            -- ====================================================
            -- 3. CATEGORIAS
            -- ====================================================
            INSERT INTO Categorias (Id, Nome, Descricao) VALUES
            (1, 'Hardware', 'Problemas físicos: Monitor, Teclado, Impressora'),
            (2, 'Software', 'Instalação, Office, Windows, Erros de sistema'),
            (3, 'Rede', 'Wi-Fi, Internet lenta, Queda de conexão'),
            (4, 'Acesso', 'Reset de senha, Conta bloqueada, Permissões'),
            (5, 'Outros', 'Dúvidas gerais e solicitações diversas');

            -- ====================================================
            -- 4. CHAMADOS (Com UsuarioId, TecnicoId e AnexoPath)
            -- ====================================================
            
            -- Chamado 1: Aberto (Bruno)
            INSERT INTO Chamados (Titulo, Descricao, DataAbertura, Status, Prioridade, CategoriaId, UsuarioId, TecnicoId, AnexoPath) VALUES
            ('Computador não liga', 'Aperto o botão de ligar e não acontece nada, nem bipa.', datetime('now', '-2 days'), 'Aberto', 'Alta', 1, 4, NULL, NULL);

            -- Chamado 2: Em Andamento (Fernanda -> Carlos)
            INSERT INTO Chamados (Titulo, Descricao, DataAbertura, Status, Prioridade, CategoriaId, UsuarioId, TecnicoId, AnexoPath) VALUES
            ('Erro ao abrir Excel', 'Aparece uma mensagem de erro de licença quando abro as planilhas do RH.', datetime('now', '-1 days'), 'Em Andamento', 'Média', 2, 5, 2, NULL);

            -- Chamado 3: Resolvido (Bruno -> Ana)
            INSERT INTO Chamados (Titulo, Descricao, DataAbertura, Status, Prioridade, CategoriaId, UsuarioId, TecnicoId, AnexoPath) VALUES
            ('Internet muito lenta', 'Não consigo acessar o site do banco, demora muito.', datetime('now', '-5 days'), 'Resolvido', 'Baixa', 3, 4, 3, NULL);

            -- Chamado 4: Aberto (Fernanda)
            INSERT INTO Chamados (Titulo, Descricao, DataAbertura, Status, Prioridade, CategoriaId, UsuarioId, TecnicoId, AnexoPath) VALUES
            ('Impressora travando papel', 'A impressora do corredor está atolando papel toda hora.', datetime('now', '-3 hours'), 'Aberto', 'Média', 1, 5, NULL, NULL);

            -- ====================================================
            -- 5. HISTÓRICO (Do chamado 2)
            -- ====================================================
            INSERT INTO Historico (ChamadoId, UsuarioId, Mensagem, DataHora) VALUES
            (2, 5, 'Preciso disso urgente para fechar a folha de pagamento.', datetime('now', '-1 days', '+10 minutes'));

            INSERT INTO Historico (ChamadoId, UsuarioId, Mensagem, DataHora) VALUES
            (2, 2, 'Olá Fernanda. Vou verificar sua licença remotamente. Pode me passar o AnyDesk?', datetime('now', '-20 hours'));

            -- ====================================================
            -- 6. ARTIGOS DA BASE DE CONHECIMENTO (Texto Puro)
            -- ====================================================

            -- Artigo 1
            INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES 
            ('Como redefinir sua senha de rede', 'Acesso', 'Passo a passo para alterar sua senha quando ela expirar.', 
            'Se você esqueceu sua senha ou ela expirou, siga os passos abaixo:

1. Pressione Ctrl + Alt + Del no seu teclado.
2. Clique na opção ""Alterar Senha"".
3. Digite sua senha antiga.
4. Digite a nova senha duas vezes (mínimo de 8 caracteres).

Nota: A nova senha não pode ser igual às suas últimas 3 senhas.', datetime('now'));

            -- Artigo 2
            INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES 
            ('Impressora não está imprimindo', 'Hardware', 'O que fazer quando a impressora não responde.', 
            'Antes de abrir um chamado, verifique os itens abaixo:

- A impressora está ligada e sem luzes vermelhas piscando?
- Há papel na bandeja correta (Bandeja 2 para A4)?
- Verifique se você selecionou a impressora correta (PRT-CORREDOR-01) no Word/Excel.

Se o problema persistir, tente reiniciar a impressora pelo botão físico.', datetime('now'));

            -- Artigo 3
            INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES 
            ('Conectando à VPN (GlobalProtect)', 'Rede', 'Acesso remoto aos arquivos da empresa (Home Office).', 
            'Para acessar a rede interna (Drive G: e H:) de casa:

1. Localize o ícone do globo cinza (GlobalProtect) na barra de tarefas (perto do relógio).
2. Clique no botão ""Connect"".
3. Digite seu usuário de rede e senha.

Quando o ícone ficar colorido, você está conectado e pode acessar as pastas.', datetime('now'));

            -- Artigo 4
            INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES 
            ('Configurar Assinatura no Outlook', 'Software', 'Padronização da assinatura de e-mail corporativo.', 
            'Para configurar sua assinatura padrão:

1. No Outlook, vá em Arquivo > Opções > Email.
2. Clique no botão ""Assinaturas"".
3. Copie o modelo abaixo e substitua seus dados:

--
Seu Nome
Departamento de Vendas
SolvIT Support Ltda.
(11) 9999-9999', datetime('now'));

            -- Artigo 5
            INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES 
            ('Excel travando ou lento', 'Software', 'Dicas para melhorar o desempenho de planilhas.', 
            'Se o Excel estiver travando ou demorando para salvar:

- Verifique se há muitas fórmulas PROCV ou SOMASE referenciando outras planilhas.
- Tente salvar o arquivo como formato .XLSB (Pasta de Trabalho Binária), que é mais leve.
- Desative a atualização automática de fórmulas em: Aba Fórmulas > Opções de Cálculo > Manual.', datetime('now'));

            -- Artigo 6
            INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES 
            ('Configurar Segundo Monitor', 'Hardware', 'Como estender a tela para dois monitores.', 
            'Após conectar o cabo HDMI no notebook:

1. Pressione as teclas Windows + P.
2. Selecione a opção ""Estender"".

Isso permite que você arraste janelas de uma tela para a outra, usando os dois monitores ao mesmo tempo.', datetime('now'));

            -- Artigo 7
            INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES 
            ('Acesso Wi-Fi para Visitantes', 'Rede', 'Qual rede e senha passar para clientes.', 
            'Visitantes não devem conectar na rede corporativa. Use os dados abaixo:

SSID (Nome da Rede): SolvIT_Visitantes
Senha do dia: Solicite na recepção (a senha muda semanalmente).

Esta rede tem apenas acesso à internet, sem acesso aos servidores internos.', datetime('now'));

            -- Artigo 8
            INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES 
            ('Como identificar E-mails suspeitos', 'Acesso', 'Dicas de segurança contra golpes.', 
            'ALERTA DE SEGURANÇA

Fique atento a e-mails que:
- Pedem urgência (""Sua conta será bloqueada hoje!"").
- Têm erros de português ou formatação estranha.
- O remetente é estranho (ex: suporte@gmail.com em vez de suporte@microsoft.com).

Nunca clique em links suspeitos. Encaminhe para o time de segurança.', datetime('now'));

            -- Artigo 9
            INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES 
            ('Limpar Cache do Chrome/Edge', 'Software', 'Resolve problemas de sites que não carregam.', 
            'Se um sistema web não abre ou mostra dados antigos:

1. Com o navegador aberto, pressione Ctrl + Shift + Delete.
2. Marque a opção ""Imagens e arquivos em cache"".
3. Clique em ""Limpar dados"".
4. Feche e abra o navegador novamente.', datetime('now'));

            -- Artigo 10
            INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES 
            ('Conta bloqueada após tentativas', 'Acesso', 'O que fazer se errou a senha 3 vezes.', 
            'Por segurança, após 3 erros consecutivos de senha, sua conta é bloqueada temporariamente.

O desbloqueio é automático após 15 minutos.
Aguarde este tempo e tente novamente com a senha correta.

Se precisar de acesso imediato, peça ao seu gestor para abrir um chamado.', datetime('now'));
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
        DataRegistro DATETIME,
        -- NOVAS COLUNAS AQUI:
        Telefone    TEXT,
        Departamento TEXT,
        Bio         TEXT
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
                connection.Execute(@"
    CREATE TABLE IF NOT EXISTS Artigos (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Titulo TEXT, Categoria TEXT, Resumo TEXT, Conteudo TEXT, DataAtualizacao DATETIME
    )");

// --- Dados de Teste (Só insere se estiver vazio) ---
var artCount = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Artigos");
if (artCount == 0)
{
    string lorem = "Siga os passos abaixo:\n1. Verifique o cabo de rede.\n2. Reinicie o modem.\n3. Entre em contato com o suporte.";

    connection.Execute("INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES (@T, @C, @R, @CC, @D)",
        new { T = "Como configurar VPN", C = "Rede", R = "Aprenda a conectar de casa.", CC = lorem, D = DateTime.Now });

    connection.Execute("INSERT INTO Artigos (Titulo, Categoria, Resumo, Conteudo, DataAtualizacao) VALUES (@T, @C, @R, @CC, @D)",
        new { T = "Erro de Login no Windows", C = "Acesso", R = "O que fazer quando a senha expira.", CC = lorem, D = DateTime.Now });
}


                // --- Preencher Dados Iniciais ---
                // Verifica se a tabela de categorias está vazia
                
            }
        }
    }
}
