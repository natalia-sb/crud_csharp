
Banco de dados:

CREATE DATABASE FuncionarioDB;

USE FuncionarioDB;

CREATE TABLE Funcionarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Cargo VARCHAR(100) NOT NULL,
    Admissao DATE NOT NULL,
    Salario DECIMAL(10, 2) NOT NULL,
    Status ENUM('Ativo', 'Inativo') NOT NULL0
);

CREATE TABLE Ferias (
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    FuncionarioId INT NOT NULL,
    DataInicio DATE NOT NULL,
    DataTermino DATE NOT NULL,
    Status ENUM('Pendente', 'Em andamento', 'Concluído') NOT NULL,
    CONSTRAINT chk_datas CHECK (DataTermino >= DataInicio)
);
