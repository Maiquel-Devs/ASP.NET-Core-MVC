CREATE DATABASE mydatabase;

USE mydatabase;

-- Autorizar o usuário do Windows a ser o proprietário do banco de dados (Permissão)
ALTER AUTHORIZATION ON DATABASE::mydatabase TO [NOTE-MAIQUELJ\Maiquel];

-- Verificar se o usuário tem permissão de db_owner
SELECT name AS mydatabase, SUSER_SNAME(owner_sid) AS Dono_Atual_Proprietario FROM sys.databases WHERE name = 'mydatabase';

-- Vasculha a tabela Usuarios
SELECT * FROM Usuarios;