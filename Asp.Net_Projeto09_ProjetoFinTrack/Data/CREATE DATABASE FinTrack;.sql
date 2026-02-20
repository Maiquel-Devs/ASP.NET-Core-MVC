CREATE DATABASE FinTrack; 

USE FinTrack;

-- Autorizar o usuário do Windows a ser o proprietário do banco de dados (Permissão)
ALTER AUTHORIZATION ON DATABASE::FinTrack TO [NOTE-MAIQUELJ\Maiquel];

-- Verificar se o usuário tem permissão de db_owner
SELECT name AS FinTrack, SUSER_SNAME(owner_sid) AS Dono_Atual_Proprietario FROM sys.databases WHERE name = 'FinTrack';

Select * From Transacoes;