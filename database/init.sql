-- 1. Criação da tabela de status da conta
CREATE TABLE IF NOT EXISTS tb_account_status (
    id INT PRIMARY KEY,
    status VARCHAR(50) NOT NULL UNIQUE,
    description VARCHAR(150) NOT NULL,
    is_active BOOLEAN
);

-- 2. Restrições de tipos de status
INSERT INTO tb_account_status (id, status, description, is_active) VALUES
    (10, 'REGULAR', 'CONTA REGULAR PARA USO', TRUE),
    (20, 'PENDENTE', 'INFORMAÇÕES DE CADASTRO PENDENTES', FALSE),
    (30, 'CANCELADO', 'CONTA ABERTA E CANCELADA', FALSE)
ON CONFLICT (id) DO NOTHING;

CREATE TABLE IF NOT EXISTS tb_account_person (
    id SERIAL PRIMARY KEY,
    name VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL,
    birthdate TIMESTAMP NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 3. Criação da tabela tb_account com a referência id_status e id_person
CREATE TABLE IF NOT EXISTS tb_account (
    id SERIAL PRIMARY KEY,
    id_person INT NOT NULL,
    id_status INT NOT NULL DEFAULT 10,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_tb_account_status
        FOREIGN KEY (id_status) 
        REFERENCES tb_account_status (id),

    CONSTRAINT fk_tb_account_person
        FOREIGN KEY (id_person) 
        REFERENCES tb_account_person (id)
);

-- 4. Dados de exemplo para pessoas
INSERT INTO tb_account_person (name, email, birthdate) VALUES
    ('Ana Martins', 'ana.martins@example.com', '1988-04-12 00:00:00'),
    ('Bruno Carvalho', 'bruno.carvalho@example.com', '1992-09-23 00:00:00'),
    ('Camila Ferreira', 'camila.ferreira@example.com', '1985-01-07 00:00:00'),
    ('Diego Almeida', 'diego.almeida@example.com', '1996-06-18 00:00:00'),
    ('Eduarda Costa', 'eduarda.costa@example.com', '1990-11-30 00:00:00')
ON CONFLICT (id) DO NOTHING;

-- 5. Dados de exemplo para contas
INSERT INTO tb_account (id_person, id_status)
SELECT seed.id_person, seed.id_status
FROM (VALUES
    (1, 10),
    (2, 20),
    (3, 10),
    (4, 30),
    (5, 10)
) AS seed(id_person, id_status)
WHERE NOT EXISTS (
    SELECT 1
    FROM tb_account existing
    WHERE existing.id_person = seed.id_person
);
