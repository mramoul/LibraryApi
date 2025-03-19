# Cahier des charges : Application de gestion de bibliothèque

## Contexte
Développer une application de gestion de bibliothèque permettant de gérer les livres, les auteurs et les emprunts via une API RESTful. L'application doit être déployée dans un environnement Docker et utiliser une base de données PostgreSQL.

## Objectifs
- Développer une API RESTful pour gérer les livres, les auteurs et les emprunts.
- Utiliser EFCore pour l'accès à une base de données PostgreSQL.
- Déployer l'application dans un conteneur Docker.
- Assurer que l'API soit testable via Swagger, déployé sur la même instance du serveur web ASP.Net Core.

## Besoins utilisateurs
1. **Gestion des livres**
   - Les utilisateurs doivent pouvoir ajouter, modifier, supprimer et consulter des livres.
   - Chaque livre doit contenir des informations telles que le titre, l'ISBN, la date de publication et l'auteur.

2. **Gestion des auteurs**
   - Les utilisateurs doivent pouvoir ajouter, modifier, supprimer et consulter des auteurs.
   - Chaque auteur doit contenir des informations telles que le nom, le prénom et la date de naissance.

3. **Gestion des emprunts**
   - Les utilisateurs doivent pouvoir enregistrer des emprunts de livres.
   - Chaque emprunt doit contenir des informations telles que le livre emprunté, la date d'emprunt et la date de retour prévue.

## Exigences fonctionnelles
1. **API RESTful**
   - L'API doit permettre les opérations CRUD (Create, Read, Update, Delete) pour chaque entité.

2. **Base de données**
   - Utiliser EFCore pour interagir avec une base de données PostgreSQL.
   - La base de données doit contenir les tables nécessaires pour stocker les informations sur les livres, les auteurs et les emprunts.

3. **Déploiement Docker**
   - Créer un fichier Dockerfile pour construire l'image de l'application.
   - Créer un fichier docker-compose.yml pour orchestrer les conteneurs de l'application et de la base de données PostgreSQL.

4. **Swagger**
   - L'API doit être testable via Swagger.
   - Swagger doit être déployé sur la même instance du serveur web ASP.Net Core que l'API RESTful.

## Livrables
1. **Code source**
   - Le code source complet de l'application, organisé de manière claire et structurée.
     - Le code source sera publié sur GitHub et un accès nous sera transmis pour accéder au code.
   - Les fichiers de configuration nécessaires pour le déploiement Docker.

2. **Documentation**
   - Un document README.md détaillant :
     - Les instructions pour configurer l'environnement de développement.
     - Les commandes pour construire et lancer l'application avec Docker.
     - Une explication des choix techniques effectués pour les aspects importants du projet.
     - Une description des fonctionnalités de l'API et des exemples de requêtes.

## Critères d'évaluation
- **Réflexion sur un problème donné** : Capacité à concevoir une solution complète et cohérente pour le projet.
- **Motivation à analyser et creuser des sujets inconnus** : Utilisation correcte des technologies demandées, même si elles ne sont pas familières.
- **Capacité à écrire de la documentation** : Clarté et exhaustivité du document README.md.
- **Capacité à être autonome** : Capacité à livrer un projet fonctionnel et bien documenté sans assistance.