CREATE DATABASE fleetmanager;
USE fleetmanager;
CREATE TABLE users(user_id INT AUTO_INCREMENT,
                   username VARCHAR(50),
                   password VARCHAR(100),
                   role VARCHAR(50),
                   PRIMARY KEY (user_id));
CREATE TABLE vehicules(immatriculation VARCHAR(8),
                       modele VARCHAR(50),
                       description VARCHAR(500),
                       kilometrage_total INT,
                       prix_litre DECIMAL(2,2),
                       PRIMARY KEY (immatriculation));
CREATE TABLE historique(histo_id INT AUTO_INCREMENT,
                        carburant DECIMAL(5,2),
                        distance INT,
                        immatriculation VARCHAR(8),
                        PRIMARY KEY (histo_id),
                        FOREIGN KEY (immatriculation) REFERENCES vehicules(immatriculation));
INSERT INTO users (username, password, role) VALUES ('admin', 'adminpassword', 'admin');

USE historique;
CREATE TRIGGER trg_maj_kilometrage
ON historique
AFTER INSERT
FOR EACH ROW
BEGIN
    UPDATE vehicules
    SET kilometrage_total = kilometrage_total + NEW.distance
    WHERE immatriculation = NEW.immatriculation;
END