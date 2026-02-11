CREATE DATABASE ProjetoAPI;

USE ProjetoAPI;

# Criar usuário e senha
CREATE USER 'UsuarioAPI'@'localhost' IDENTIFIED BY 'SenhaAPI';

# Conceder privilégios ao banco projeto_crud
GRANT ALL PRIVILEGES ON ProjetoAPI.* TO 'UsuarioAPI'@'localhost';

# Aplicar as permissões
FLUSH PRIVILEGES;

# Conferir permissões
SHOW GRANTS FOR 'UsuarioAPI'@'localhost';


SHOW TABLES;

SELECT * FROM usuariodb;