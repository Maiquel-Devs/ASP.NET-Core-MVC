CREATE DATABASE VocabularioDiario;

USE VocabularioDiario;

-- Autorizar o usuário do Windows a ser o proprietário do banco de dados (Permissão)
ALTER AUTHORIZATION ON DATABASE::VocabularioDiario TO [NOTE-MAIQUELJ\Maiquel];

-- Verificar se o usuário tem permissão de db_owner
SELECT name AS VocabularioDiario, SUSER_SNAME(owner_sid) AS Dono_Atual_Proprietario FROM sys.databases WHERE name = 'VocabularioDiario';

-- Vasculha a tabela Usuarios
SELECT * FROM Palavras;

SELECT * FROM RegistroRespostas;