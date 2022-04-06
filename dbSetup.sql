CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
--
--
CREATE TABLE IF NOT EXISTS cars(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name TEXT NOT NULL,
  description TEXT,
  price DECIMAL(9, 2)
) default charset utf8;
--
--
/*NOTE POST*/
INSERT INTO
  cars (name, description, price)
VALUES
  ("Mickster", "Nacho cheese truck", 24.72);
  /*NOTE GET*/
SELECT
  *
FROM
  cars;
  /*NOTE GET BY ___ */
SELECT
  *
FROM
  cars
WHERE
  id = 2;
  /*NOTE PUT */
UPDATE
  cars
SET
  name = "Samobile",
  description = "Fast as fuq",
  price = 66.99
WHERE
  id = 1;
  /*NOTE DELETE */
DELETE FROM
  cars
WHERE
  id = 2
LIMIT
  1;