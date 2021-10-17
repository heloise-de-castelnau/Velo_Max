using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace VELOMAX_DEMY_DECASTELNAU
{
    class Program
    {
        static void Main(string[] args)
        {
            AffichageConsole();

        }
        
        static void AffichageConsole()
        {

            Console.WriteLine("██╗░░░██╗███████╗██╗░░░░░░█████╗░███╗░░░███╗░█████╗░██╗░░██╗");
            Console.WriteLine("██║░░░██║██╔════╝██║░░░░░██╔══██╗████╗░████║██╔══██╗╚██╗██╔╝");
            Console.WriteLine("╚██╗░██╔╝█████╗░░██║░░░░░██║░░██║██╔████╔██║███████║░╚███╔╝░");
            Console.WriteLine("░╚████╔╝░██╔══╝░░██║░░░░░██║░░██║██║╚██╔╝██║██╔══██║░██╔██╗░");
            Console.WriteLine("░░╚██╔╝░░███████╗███████╗╚█████╔╝██║░╚═╝░██║██║░░██║██╔╝╚██╗");
            Console.WriteLine("░░░╚═╝░░░╚══════╝╚══════╝░╚════╝░╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝");
            Console.WriteLine();
            Console.WriteLine("Bienvenue sur VeloMax!");
            string answer;
            Console.WriteLine("Vous êtes ? Admin ou Evaluateur (A), Client Boutique(CB), Client Individuel (CI), Fournisseur(F) ,Utilisateur Bozo(B) >");
            answer = Console.ReadLine();
            switch (answer)
            {

                case "A":
                    MethodeG();
                    break;
                case "CB":
                    Methode_CliendBout();
                    break;
                case "CI":
                    Methode_CliendInd();
                    break;
                case "F":
                    Methode_Fournisseur();
                    break;
                case "B":
                    Methode_Bozo();
                    break;


            }


        }

        #region Méthodes Interface Admin,Clients,Fournisseurs
        //Methode Pour L'Admin ou l'Evaluateur
        static void MethodeG()
        {
            int selection;
            string action;

            Console.WriteLine();

            Console.WriteLine("Que souhaitez-vous faire ?");
            Console.WriteLine("1-Afficher Pièces, Clients, Fournisseurs ou Commandes ");
            Console.WriteLine("2-Créer Pièces, Clients, Fournisseurs ou Commandes ");
            Console.WriteLine("3-Supprimer Pièces, Clients, Fournisseurs ou Commandes");
            Console.WriteLine("4-Mettre à jour Pièces, Clients, Fournisseurs ou Commandes");
            Console.WriteLine("5-Accéder au stock");
            Console.WriteLine("6-Mode Demo");
            Console.WriteLine("7-Requetes Spéciales");
            selection = Convert.ToInt32(Console.ReadLine());


            switch (selection)
            {
                case 1:
                    Console.WriteLine("Vous souhaitez agir sur Pièce(P),Clients Individuel(CI), Clients Boutique(CB),Fournisseurs(F) ou Commandes(CO)");
                    action = Console.ReadLine();
                    switch (action)
                    {
                        case "P":
                            AffichePieces();
                            break;
                        case "CI":
                            AfficheClientsInd();
                            break;
                        case "CB":
                            AffichageClientsBout();
                            break;
                        case "F":
                            AffichageFournisseurs();
                            break;
                        case "CO":
                            AffichageCommandes();
                            break;
                    }
                    break;

                case 2:
                    Console.WriteLine("Vous souhaitez agir sur Pièce(P),Clients Individuel(CI), Clients Boutique(CB),Fournisseurs(F) ou Commandes(CO)");
                    action = Console.ReadLine();
                    switch (action)
                    {
                        case "P":
                            //Methode à vérifier
                            break;
                        case "CI":
                            CreaClientsInd();
                            break;
                        case "CB":
                            CreaClientsBout();
                            break;
                        case "F":
                            CreaFournisseurs();
                            break;
                        case "CO":
                            CreaCommandes();
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("Vous souhaitez agir sur Pièce(P),Clients Individuel(CI), Clients Boutique(CB),Fournisseurs(F) ou Commandes(CO)");
                    action = Console.ReadLine();
                    switch (action)
                    {
                        case "P":
                            SuppPiece();
                            break;
                        case "CI":
                            SuppClientsInd();
                            break;
                        case "CB":
                            SuppClientsBout();
                            break;
                        case "F":
                            SuppFournisseurs();
                            break;
                        case "CO":
                            SuppCommandes();
                            break;
                    }
                    break;

                case 4:
                    Console.WriteLine("Vous souhaitez agir sur Pièce(P),Clients Individuel(CI), Clients Boutique(CB),Fournisseurs(F) ou Commandes(CO)");
                    action = Console.ReadLine();
                    switch (action)
                    {
                        case "P":
                            MAJPieces();
                            break;
                        case "CI":
                            MAJClientInd();
                            break;
                        case "CB":
                            MAJClientBout();
                            break;
                        case "F":
                            MAJFournisseurs();
                            break;
                        case "CO":
                            MAJCommandes_General();
                            break;
                    }
                    break;
                case 5:
                    AfficherStock();
                    break;

                case 6:
                    //Console.BackgroundColor = ConsoleColor.Blue;
                    //1
                    Console.WriteLine();
                    Console.WriteLine("1.Nombre de clients");

                    AfficheNombreClients();
                    Console.WriteLine("Appuyez sur un touche du clavier pour passer à l'affichage suivant");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();

                    //2
                    Console.WriteLine("2.Noms des clients avec le cumul de toutes ses commandes en euros");
                    Clients_commande();
                    Console.WriteLine("Appuyez sur un touche du clavier pour passer à l'affichage suivant");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();

                    //3
                    Console.WriteLine("3.Liste des produits ayant une quantité en stock <= 2");
                    AffichePiceQuantite_inf2();
                    Console.WriteLine("Appuyez sur un touche du clavier pour passer à l'affichage suivant");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();

                    //4
                    Console.WriteLine("4.Nombres de pièces et/ ou vélos fournis par fournisseur.");
                    Fournisseur_fournit();

                    Console.WriteLine("Appuyez sur un touche du clavier pour passer à l'affichage suivant");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();

                    //5
                    Console.WriteLine("5.Export en XML / JSON d’une table");
                    Console.WriteLine();
                    Console.WriteLine("Export XML done");
                    Console.WriteLine();
                    Export_XML();
                    Console.WriteLine();
                    Console.WriteLine("Export JSON done");
                    Console.WriteLine();
                    Export_JSON();
                    Console.WriteLine("Appuyez sur un touche du clavier pour passer à l'affichage suivant");
                    Console.ReadKey();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    MethodeG();

                    break;
                case 7:
                    string answer;
                    Console.WriteLine("A quelle requête voulez-vous accéder ?");
                    Console.WriteLine("Synchronisé (S), avec Auto-Jointure (A), avec Union(U) ou les unes à la suite des autres(T)");
                    answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "S":
                            Requete_synchronise();
                            break;
                        case "A":
                            Requete_auto_jointure();
                            break;
                        case "U":
                            Requete_union();
                            break;
                        case "T":
                            Requete_synchronise();
                            Console.WriteLine();
                            Console.WriteLine("Appuyez sur un touche du clavier pour passer à l'affichage suivant");
                            Console.ReadKey();
                            Requete_auto_jointure();
                            Console.WriteLine();
                            Console.WriteLine("Appuyez sur un touche du clavier pour passer à l'affichage suivant");
                            Console.ReadKey();
                            Console.WriteLine();
                            Requete_union();
                            Console.ReadKey();
                            Console.Clear();
                            MethodeG();
                            break;

                    }

                    break;
            }


        }   //Manque passe commande

        //Methode Pour le client Boutique
        static void Methode_CliendBout()
        {

            string nouveau;

            Console.WriteLine("Bonjour, vous êtes un nouveau client ?(Y/N)");
            nouveau = Console.ReadLine();
            if (nouveau == "Y")
            {
                CreaClientsBout();

            }

            Console.WriteLine();
            string nom_compagnie;
            Console.WriteLine("Veuillez tapper votre nom d'Entreprise pour vérification");
            nom_compagnie = Console.ReadLine();


            string choice;
            Console.WriteLine("Que souhaitez-vous faire ?");
            Console.WriteLine("0. Afficher le catalogue");
            Console.WriteLine("1. Passer Commande");
            Console.WriteLine("2. Accéder à vos commandes en cours");
            Console.WriteLine("3. Supprimer une commande");
            Console.WriteLine("4. Exit");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    AffichePieces();
                    Console.ReadKey();
                    AfficheVelos();
                    Console.ReadKey();
                    Methode_CliendBout();
                    break;
                case "1":
                    CreaCommandes_Clients();
                    Console.ReadKey();
                    Methode_CliendBout();
                    break;
                case "2":
                    Console.WriteLine("Voici la liste de vos Commandes:");
                    AffichageCommandes_Bout(nom_compagnie);
                    Console.ReadKey();
                    Methode_CliendBout();
                    break;
                case "3":
                    Console.WriteLine("Voici la liste de vos Commandes:");
                    AffichageCommandes_Bout(nom_compagnie);
                    Console.WriteLine();
                    SuppCommandes();
                    Console.ReadKey();
                    Methode_CliendBout();
                    break;
                case "4":
                    AffichageConsole();
                    break;




            }
        }

        //Methode Pour le client Individuel
        static void Methode_CliendInd()  //Manque passe commande
        {
            string nouveau;
            string answer;
            Console.WriteLine("Bonjour, vous êtes un nouveau client ?(Y/N)");
            nouveau = Console.ReadLine();
            if (nouveau == "Y")
            {
                CreaClientsInd();

            }
            Console.WriteLine("");
            Console.WriteLine("Pour naviguer vous aurez_besoin de votre numéro client , voulez-vous y accéder ? (Y/N)");
            answer = Console.ReadLine();
            if (answer == "Y")
            {
                Info_du_client_Ind();

            }
            Console.WriteLine("");
            string no_client;
            Console.WriteLine("Veuillez tapper votre numéro client pour vérification");
            no_client = Console.ReadLine();
            string choice;
            Console.WriteLine("Que souhaitez-vous faire ?");
            Console.WriteLine("0. Afficher le catalogue");
            Console.WriteLine("1. Passer Commande");
            Console.WriteLine("2. Accéder à vos commandes en cours");
            Console.WriteLine("3. Supprimer une commande");
            Console.WriteLine("4. Exit");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    AffichePieces();
                    Console.ReadKey();
                    AfficheVelos();
                    Console.WriteLine();
                    Methode_CliendInd();

                    break;
                case "1":
                    CreaCommandes_Clients();
                    Console.WriteLine();
                    Methode_CliendInd();

                    break;

                case "2":
                    Console.WriteLine("Voici la liste de vos Commandes:");
                    AffichageCommandes_Ind(no_client);
                    Console.WriteLine();
                    Methode_CliendInd();

                    break;
                case "3":
                    Console.WriteLine("Voici la liste de vos Commandes:");
                    AffichageCommandes_Ind(no_client);
                    Console.WriteLine();
                    SuppCommandes();
                    Console.WriteLine();
                    Methode_CliendInd();

                    break;
                case "4":
                    AffichageConsole();
                    break;

            }


        }


        //Methode Pour le Fournisseur
        static void Methode_Fournisseur()
        {
            string nouveau;
            string nom_entreprise;
            Console.WriteLine("Bonjour, vous êtes un nouveau fournisseur ?(Y/N)");
            nouveau = Console.ReadLine();
            if (nouveau == "Y")
            {
                CreaFournisseurs();

            }
            Console.WriteLine("");

            Console.WriteLine("Veuillez renseigner le nom de votre entreprise :");
            nom_entreprise = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Pour la suite des requêtes vous aurez besoin de votre siret:");
            Console.WriteLine("Si les informations suivantes sont correctes appuyer sur la touche enter");
            AffichageFournisseurs_pour1(nom_entreprise);

            string choice;
            Console.WriteLine("Que souhaitez-vous faire ?");
            Console.WriteLine("0. Afficher le catalogue");
            Console.WriteLine("1. Modifier les informations fournisseurs");
            Console.WriteLine("2. Afficher les informations du stock que vous nous fournissez actuellement");
            Console.WriteLine("3. Modifier des informations du stock que vous nous fournissez actuellement");
            Console.WriteLine("4. Supprimer des informations du stock que vous nous fournissez actuellement");
            Console.WriteLine("5. Ajouter des pièces que vous pouvez nous fournir");
            Console.WriteLine("6. Exit");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    AffichePieces();
                    Console.ReadKey();
                    AfficheVelos();
                    break;
                case "1":
                    MAJFournisseurs();
                    break;
                case "2":
                    Affichage_Fournit_par_fournisseur();
                    break;
                case "3":
                    Fournisseur_modifie_fournit();
                    break;
                case "4":
                    Fournisseur_supprime_fournit();
                    break;
                case "5":
                    Fournisseur_ajoute_fournit();
                    break;
                case "6":
                    AffichageConsole();
                    break;

            }

        }


        //Methode Pour l'utilisateur Bozo
        static void Methode_Bozo()
        {
            string action;
            Console.WriteLine("Vous souhaitez afficher Pièce(P),Clients Individuel(CI), Clients Boutique(CB),Fournisseurs(F), Commandes(CO) ou Exit(E)");
            action = Console.ReadLine();
            switch (action)
            {
                case "P":
                    AffichePieces_Bozo();
                    Console.WriteLine();
                    Methode_Bozo();
                    break;
                case "CI":
                    AfficheClientsInd_Bozo();
                    Console.WriteLine();
                    Methode_Bozo();
                    break;
                case "CB":
                    AffichageClientsBout_Bozo();
                    Console.WriteLine();
                    Methode_Bozo();
                    break;
                case "F":
                    AffichageFournisseurs_Bozo();
                    Console.WriteLine();
                    Methode_Bozo();
                    break;
                case "CO":
                    AffichageCommandes_Bozo();
                    string no_commande_bozo;
                    Console.WriteLine("Choisir un numéro de commande");
                    no_commande_bozo = Console.ReadLine();
                    Console.WriteLine();
                    AffichageContientPiece_Bozo(no_commande_bozo);
                    Console.WriteLine();
                    AffichageContientBic_Bozo(no_commande_bozo);
                    Console.WriteLine();
                    Methode_Bozo();
                    break;

                case "E":
                    AffichageConsole();
                    break;
            }



        }

        #endregion


        #region Méthodes du Module statistique


        static void Rapport_stat()
        {
            //1. Produire un rapport statistique présentant les quantités vendues de chaque item qui se
            //trouve dans l’inventaire de VéloMax.
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region affichage quantites 
            Console.WriteLine("Pièces et leurs quantités commandés respectives :");
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select no_piece from contient_piece join commande on commande.no_commande = contient_piece.no_commande ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string no_piece;
            string quantite_piece;
            HashSet<string> les_pieces_du_stock = new HashSet<string>();
            while (reader.Read())   // parcours ligne par ligne
            {
                no_piece = reader.GetString(0);
                les_pieces_du_stock.Add(no_piece);
            }

            reader.Close();

            foreach (string i in les_pieces_du_stock)
            {

                MySqlCommand command1 = maConnexion.CreateCommand();
                command1.CommandText = "select no_piece, sum(quantite_piece) from contient_piece join commande on commande.no_commande = contient_piece.no_commande where no_piece='" + i + "';";

                MySqlDataReader reader1;
                reader1 = command1.ExecuteReader();

                while (reader1.Read())   // parcours ligne par ligne
                {
                    no_piece = reader1.GetString(0);
                    quantite_piece = reader1.GetString(1);
                    Console.WriteLine(no_piece + ": " + quantite_piece);
                }

                reader1.Close();



            }



            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = "select no_bicyclette from contient_bicyclette join commande on commande.no_commande = contient_bicyclette.no_commande order by quantite_bicyclette desc;";

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();
            string no_bicyclette;
            string quantite_bicyclette;
            HashSet<string> les_types_de_velos = new HashSet<string>();
            Console.WriteLine("Vélos et leurs quantités commandés respectives :");
            while (reader2.Read())   // parcours ligne par ligne
            {
                no_bicyclette = reader2.GetString(0);
                les_types_de_velos.Add(no_bicyclette);


            }
            reader2.Close();

            foreach (string i in les_types_de_velos)
            {

                MySqlCommand command1 = maConnexion.CreateCommand();
                command1.CommandText = "select no_bicyclette, sum(quantite_bicyclette) from contient_bicyclette join commande on commande.no_commande = contient_bicyclette.no_commande where no_bicyclette='" + i + "';";

                MySqlDataReader reader1;
                reader1 = command1.ExecuteReader();

                while (reader1.Read())   // parcours ligne par ligne
                {
                    no_bicyclette = reader1.GetString(0);
                    quantite_bicyclette = reader1.GetString(1);
                    Console.WriteLine(no_bicyclette + ": " + quantite_bicyclette);
                }

                reader1.Close();

            }


            //List<string> les_pieces = new List<string>();
            //foreach(string i in les_types_de_velos)
            //{
            //    string cherche_pieces_velo = "Select * from assemblage join bicyclette on assemblage.nom_bicyclette = bicyclette.nom_bicyclette where no_bicyclette = '" + i + "';";
            //    MySqlCommand pieceDuVelo = maConnexion.CreateCommand();
            //    pieceDuVelo.CommandText = cherche_pieces_velo;
            //    MySqlDataReader reader4;
            //    reader4 = pieceDuVelo.ExecuteReader();
            //    while (reader4.Read())   // parcours ligne par ligne
            //    {
            //        for (int j = 3; j < reader4.FieldCount - 5; j++)
            //        {
            //            if (!reader4.IsDBNull(j))
            //            {
            //                no_piece = reader4.GetString(j);
            //                les_pieces.Add(no_piece);
            //                Console.Write(no_piece +",");
            //            }
            //            else
            //            {
            //                no_piece = "null";
            //            }

            //        }
            //        //pour un Vélo
            //        Console.WriteLine();

            //    }
            //    reader4.Close();

            //}

            #endregion

        }  // A CONTINUER Si temps faire somme par vélos //List <(string Mot, int Nb)> lst = new List<(string,int)>();

        static void Membre_Programme()
        {
            //2. Produire la liste des membres pour chaque programme d’adhésion.
            //3. Affichez également la date d’expiration des adhésions
            //select nom_client, prenom_client, description_fidelio,adhere.date_paiement from client_individuel join adhere on client_individuel.no_client=adhere.no_client
            //join fidelio on fidelio.no_fidelio = adhere.no_fidelio;

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region affichage membre
            Console.WriteLine("Voici les clients par programme fidélio et leur date d'expiration respective");
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select nom_client, prenom_client, description_fidelio,adhere.date_paiement from client_individuel join adhere on client_individuel.no_client=adhere.no_client join fidelio on fidelio.no_fidelio = adhere.no_fidelio;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string nom_client;
            string prenom_client;
            string description_fidelio;
            string date_paiement;
            HashSet<string> les_prgm_fidelios = new HashSet<string>();
            List<string> les_clients_nom = new List<string>();
            List<string> les_clients_prenom = new List<string>();
            List<string> les_clients_paiement = new List<string>();
            List<string> les_clients_fidelio = new List<string>();
            while (reader.Read())   // parcours ligne par ligne
            {

                description_fidelio = reader.GetString(2);
                les_clients_fidelio.Add(description_fidelio);
                les_prgm_fidelios.Add(description_fidelio);
                nom_client = reader.GetString(0);
                les_clients_nom.Add(nom_client);
                prenom_client = reader.GetString(1);
                les_clients_prenom.Add(prenom_client);
                date_paiement = reader.GetString(3);
                les_clients_paiement.Add(date_paiement);

            }
            reader.Close();

            foreach (string j in les_prgm_fidelios)
            {
                Console.WriteLine(j);
                Console.WriteLine();
                for (int i = 0; i < les_clients_nom.Count; i++)
                {
                    if (les_clients_fidelio[i] == j)
                    {
                        Console.WriteLine(les_clients_nom[i] + "," + les_clients_prenom[i] + "," + les_clients_paiement[i]);
                    }

                }


            }



            #endregion

        }

        static void Meilleur_Clients()
        {
            //4. Retrouvez-le(ou les) meilleur client en fonction des quantités vendues en nombre de
            //pièces vendues ou en cumul en euros

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Classement des clients");

            #region Pour un client individuel
            Console.WriteLine("Clients individuels et leurs quantité d'achats respectifs");

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select no_client,nom_client,prenom_client from client_individuel";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string nombre_clients_ind;
            List<string> clients = new List<string>();
            string nom_client;
            List<string> noms_clients = new List<string>();
            string prenom_client;
            List<string> prenoms_clients = new List<string>();
            while (reader.Read())   // parcours ligne par ligne
            {
                nombre_clients_ind = reader.GetString(0);
                clients.Add(nombre_clients_ind);
                nom_client = reader.GetString(1);
                noms_clients.Add(nom_client);
                prenom_client = reader.GetString(2);
                prenoms_clients.Add(prenom_client);

            }
            reader.Close();

            string somme_achat_client;
            List<string> Sommes = new List<string>();
            string somme_achat_client_velos;
            List<string> Sommes_velos = new List<string>();
            foreach (string i in clients)
            {
                MySqlCommand command2 = maConnexion.CreateCommand();
                command2.CommandText = "select sum(quantite_piece) from contient_piece join commande on commande.no_commande=contient_piece.no_commande where commande.no_client='" + i + "';";

                MySqlDataReader reader2;
                reader2 = command2.ExecuteReader();


                while (reader2.Read())   // parcours ligne par ligne
                {
                    if (!reader2.IsDBNull(0))
                    {
                        somme_achat_client = reader2.GetString(0);
                    }
                    else
                    {
                        somme_achat_client = "0";
                    }

                    Sommes.Add(somme_achat_client);
                }
                reader2.Close();

                //select sum(quantite_bicyclette) from contient_bicyclette join commande on commande.no_commande=contient_bicyclette.no_commande where no_client=1;
                MySqlCommand command3 = maConnexion.CreateCommand();
                command3.CommandText = "select sum(quantite_bicyclette) from contient_bicyclette join commande on commande.no_commande=contient_bicyclette.no_commande where commande.no_client='" + i + "';";

                MySqlDataReader reader3;
                reader3 = command3.ExecuteReader();


                while (reader3.Read())   // parcours ligne par ligne
                {
                    if (!reader3.IsDBNull(0))
                    {
                        somme_achat_client_velos = reader3.GetString(0);
                    }
                    else
                    {
                        somme_achat_client_velos = "0";
                    }

                    Sommes_velos.Add(somme_achat_client_velos);
                }
                reader3.Close();


            }

            for (int i = 0; i < clients.Count; i++)
            {

                Console.WriteLine(noms_clients[i] + ": " + Sommes[i] + " pièces et " + Sommes_velos[i] + " vélos.");
            }




            #endregion

            #region Pour un client Boutique
            Console.WriteLine("Clients Boutiques et leurs quantité d'achats respectifs");

            MySqlCommand command4 = maConnexion.CreateCommand();
            command4.CommandText = "select distinct nom_compagnie from commande order by nom_compagnie desc";

            MySqlDataReader reader4;
            reader4 = command4.ExecuteReader();
            string nombre_clients_bout;
            List<string> clients_bout = new List<string>();

            while (reader4.Read())   // parcours ligne par ligne
            {

                if (!reader4.IsDBNull(0))
                {
                    nombre_clients_bout = reader4.GetString(0);
                    clients_bout.Add(nombre_clients_bout);
                }



            }
            reader4.Close();

            string somme_achat_client_bout;
            List<string> Sommes_bout = new List<string>();
            string somme_achat_client_velos_bout;
            List<string> Sommes_velos_bout = new List<string>();



            foreach (string i in clients_bout)
            {
                MySqlCommand command5 = maConnexion.CreateCommand();
                command5.CommandText = "select sum(quantite_piece) from contient_piece join commande on commande.no_commande=contient_piece.no_commande where commande.nom_compagnie='" + i + "';";

                MySqlDataReader reader5;
                reader5 = command5.ExecuteReader();


                while (reader5.Read())   // parcours ligne par ligne
                {
                    if (!reader5.IsDBNull(0))
                    {
                        somme_achat_client_bout = reader5.GetString(0);
                    }
                    else
                    {
                        somme_achat_client_bout = "0";
                    }

                    Sommes_bout.Add(somme_achat_client_bout);
                }
                reader5.Close();

                //select sum(quantite_bicyclette) from contient_bicyclette join commande on commande.no_commande=contient_bicyclette.no_commande where no_client=1;
                MySqlCommand command6 = maConnexion.CreateCommand();
                command6.CommandText = "select sum(quantite_bicyclette) from contient_bicyclette join commande on commande.no_commande=contient_bicyclette.no_commande where commande.nom_compagnie='" + i + "';";

                MySqlDataReader reader6;
                reader6 = command6.ExecuteReader();


                while (reader6.Read())   // parcours ligne par ligne
                {
                    if (!reader6.IsDBNull(0))
                    {
                        somme_achat_client_velos_bout = reader6.GetString(0);
                    }
                    else
                    {
                        somme_achat_client_velos_bout = "0";
                    }

                    Sommes_velos_bout.Add(somme_achat_client_velos_bout);
                }
                reader6.Close();


            }

            for (int i = 0; i < clients_bout.Count; i++)
            {

                Console.WriteLine(clients_bout[i] + ": " + Sommes_bout[i] + " pièces et " + Sommes_velos_bout[i] + " vélos.");
            }


            #endregion


        }

        static void Analyses_Moyennes()
        {

            //5. Faîtes une analyse des commandes : moyenne des montants des commandes, moyenne du
            //nombre de pièces ou de vélos par commande.

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region affichage Moyenne

            Console.WriteLine("Moyenne des montants par commande ");
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select round(avg(prix_fournisseur_piece* quantite_piece),2) from fournit join piece on fournit.no_piece = piece.no_piece join contient_piece on contient_piece.no_piece = piece.no_piece join commande on commande.no_commande = contient_piece.no_commande group by contient_piece.no_commande;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string moyenne = "";
            int compteur = 1;
            while (reader.Read())   // parcours ligne par ligne
            {
                moyenne = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                Console.WriteLine("commande " + compteur + " :" + moyenne);
                compteur++;
            }
            reader.Close();
            #endregion

            #region affichage piece moyenne
            Console.WriteLine("");
            Console.WriteLine("Moyenne du nombre de pièces par commande ");
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = "select round(avg(quantite_piece),1) from contient_piece group by no_commande;";

            MySqlDataReader reader1;
            reader1 = command1.ExecuteReader();

            string moyenne_piece = "";
            int compteur2 = 1;
            while (reader1.Read())   // parcours ligne par ligne
            {
                moyenne_piece = reader1.GetString(0); // récupération 1ère colonne (selon la requête !)
                Console.WriteLine("commande " + compteur2 + " :" + moyenne_piece);
                compteur2++;
            }
            reader1.Close();
            #endregion

            #region affichage velos moyenne
            Console.WriteLine("");
            Console.WriteLine("Moyenne du nombre de vélos par commande ");
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = "select round(avg(quantite_bicyclette),1) from contient_bicyclette group by no_commande;";

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();

            string moyenne_bicyclette = "";
            int compteur3 = 1;
            while (reader2.Read())   // parcours ligne par ligne
            {
                moyenne_bicyclette = reader2.GetString(0); // récupération 1ère colonne (selon la requête !)
                Console.WriteLine("commande " + compteur3 + " :" + moyenne_bicyclette);
                compteur3++;
            }
            reader2.Close();
            #endregion


        }


        #endregion


        #region Clients Ind_Bout

        static void Info_du_client_Ind() //Accéder au numéro client
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region affichage numero client 
            string nom;
            string prenom;
            Console.WriteLine("Boujour, rentrez votre nom :");
            nom = Console.ReadLine();
            Console.WriteLine("Boujour, rentrez votre prenom :");
            prenom = Console.ReadLine();
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select no_client from client_individuel where nom_client='" + nom + "' and prenom_client='" + prenom + "';";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string no_client;

            while (reader.Read())   // parcours ligne par ligne
            {
                no_client = reader.GetString(0);

                Console.WriteLine("Votre numéro client est :" + no_client);


            }
            reader.Close();



            #endregion


        }

        static void AffichageCommandes_Ind(string no_client)
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region affichage commande

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from commande where no_client='" + no_client + "';";
            //`commande`(`no_commande`,`date_commande`,`adresse_livraison`,`date_livraison`,`nom_compagnie`,`no_client`) 
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string no_commande = "";
            string date_commande = "";
            string adresse_livraison = "";
            string date_livraison = "";
            string nom_compagnie = "";

            Console.WriteLine("no_commande|date_commande|adresse_livraison|date_livraison|nom_compagnie|no_client");


            while (reader.Read())   // parcours ligne par ligne
            {
                no_commande = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                date_commande = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                adresse_livraison = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                date_livraison = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                if (!reader.IsDBNull(4))
                {
                    nom_compagnie = reader.GetString(4);
                }
                else
                {
                    nom_compagnie = "null";
                }



                Console.WriteLine(no_commande + " : " + date_commande + " , " + adresse_livraison + " , " + date_livraison);

                Console.WriteLine();
            }
            reader.Close();
            #endregion

        }


        static void AffichageCommandes_Bout(string nom_compagnie)
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region affichage commande

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from commande where nom_compagnie='" + nom_compagnie + "';";
            //`commande`(`no_commande`,`date_commande`,`adresse_livraison`,`date_livraison`,`nom_compagnie`,`no_client`) 
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string no_commande = "";
            string date_commande = "";
            string adresse_livraison = "";
            string date_livraison = "";
            //string nom_compagnie = "";

            Console.WriteLine("no_commande|date_commande|adresse_livraison|date_livraison");


            while (reader.Read())   // parcours ligne par ligne
            {
                no_commande = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                date_commande = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                adresse_livraison = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                date_livraison = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)


                Console.WriteLine(no_commande + " : " + date_commande + " , " + adresse_livraison + " , " + date_livraison);

                Console.WriteLine();
            }
            reader.Close();
            #endregion

        }



        static void CreaCommandes_Clients()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Création des Commandes 
            //`velomax`.`commande`(`no_commande`,`date_commande`,`adresse_livraison`,`date_livraison`,`nom_compagnie`,`no_client`)  
            Console.WriteLine("--- Création de commandes");

            // Attributs de la Table Commande

            string no_commande;
            MySqlParameter date_commande = new MySqlParameter("@date_commande", MySqlDbType.DateTime);
            MySqlParameter adresse_livraison = new MySqlParameter("@adresse_livraison", MySqlDbType.VarChar);
            MySqlParameter date_livraison = new MySqlParameter("@date_livraison", MySqlDbType.DateTime);

            string nom_compagnie;
            int no_client;
            string lecture_no_client;
            Console.WriteLine("Ajouter une commande : ");

            Console.WriteLine("--- Caractéristiques de la commande à CREER (si non défini écrire null)");

            Console.Write("Saisir le numéro de la commande à créer (e.g 10) : ");
            no_commande = Console.ReadLine();
            Console.Write("Saisir la date d'aujourdhui, date de la commande (e.g 2000-01-01) :");
            date_commande.Value = Console.ReadLine();
            Console.Write("Saisir  l'adresse de la livraison  (e.g 1 avenue des pres) : ");
            adresse_livraison.Value = Console.ReadLine();

            date_livraison.Value = Convert.ToString(Convert.ToInt32(date_commande.Value) + 6);
            Console.Write("Saisir le nom de l'entreprise si client Boutique (e.g Veloworld) : ");
            nom_compagnie = Console.ReadLine();
            Console.Write("Saisir le numéro de l'acheteur si client Individuel (e.g 1) : ");
            lecture_no_client = Console.ReadLine();
            string insertCommande;
            if (lecture_no_client == "null")
            {
                insertCommande = "INSERT INTO commande VALUES ('" + no_commande + "', @date_commande, @adresse_livraison, @date_livraison,'" + nom_compagnie + "',null);";
            }
            else
            {
                no_client = Convert.ToInt32(Console.ReadLine());
                insertCommande = "INSERT INTO commande VALUES ('" + no_commande + "', @date_commande, @adresse_livraison, @date_livraison,null," + no_client + ");";
            }



            MySqlCommand command_insert_commande = maConnexion.CreateCommand();
            command_insert_commande.CommandText = insertCommande;
            command_insert_commande.Parameters.Add(date_commande);
            command_insert_commande.Parameters.Add(adresse_livraison);
            command_insert_commande.Parameters.Add(date_livraison);

            try
            {
                command_insert_commande.ExecuteNonQuery();
                Console.WriteLine("Commande créée !");
                string directory;
                int quantite;
                Console.WriteLine("Votre commande comporte-t-elle des pièces(P), des vélos(V) ou les deux(PV)?");
                directory = Console.ReadLine();

                switch (directory)
                {
                    case "P":
                        Console.WriteLine("Combient de pièces voulez-vous ajouter ?");
                        quantite = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < quantite; i++)
                        {
                            Commande_contient_piece(no_commande);

                        }

                        break;

                    case "V":
                        Console.WriteLine("Combient de bicyclette voulez-vous ajouter ?");
                        quantite = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < quantite; i++)
                        {
                            Commande_contient_bicyclette(no_commande);
                        }

                        break;

                    case "PV":
                        Console.WriteLine("Combient de pièces voulez-vous ajouter ?");
                        quantite = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < quantite; i++)
                        {
                            Commande_contient_piece(no_commande);
                        }
                        Console.WriteLine("Combient de bicyclette voulez-vous ajouter ?");
                        quantite = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < quantite; i++)
                        {
                            Commande_contient_bicyclette(no_commande);
                        }

                        break;
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_insert_commande.Dispose();
            #endregion
        }

        #endregion


        #region Fournisseur

        static void Affichage_Fournit_par_fournisseur() //Affichage de fournit
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region affichage pièces fournisseur

            string siret;
            string nom;
            Console.WriteLine("Boujour, rentrez votre nom d'Entreprise :");
            nom = Console.ReadLine();
            Console.WriteLine("Merci " + nom + " de fournir VeloMax");
            Console.WriteLine("Rentrez votre siret :");
            siret = Console.ReadLine();
            Console.WriteLine("");
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select no_piece,prix_fournisseur_piece,delai_fournisseur_piece from fournit where siret='" + siret + "';";
            string no_piece;
            string prix_fournisseur;
            string delai_fournisseur;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            Console.WriteLine("Voici le nom, le prix et le délai des pièces que vous nous fournissez actuellement : ");
            Console.WriteLine("");
            while (reader.Read())   // parcours ligne par ligne
            {
                no_piece = reader.GetString(0);
                prix_fournisseur = reader.GetString(1);
                delai_fournisseur = reader.GetString(2);

                Console.WriteLine(no_piece + ": " + prix_fournisseur + "," + delai_fournisseur);
            }
            reader.Close();



            #endregion


        }

        static void AffichageFournisseurs_pour1(string nom_entreprise)
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region affichage fournisseurs

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from fournisseur where nom_entreprise='" + nom_entreprise + "';";
            //`fournisseur`(`siret`,`nom_entreprise`,`contact_entreprise`,`adresse_entreprise`,`libelle_satisfaction`)
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string siret = "";

            string contact_entreprise = "";
            string adresse_entreprise = "";
            string libelle_satisfaction = "";

            Console.WriteLine("siret|nom_entreprise|contact_entreprise|adresse_entreprise|libelle_satisfaction");
            while (reader.Read())   // parcours ligne par ligne
            {
                siret = reader.GetString(0); // récupération 1ère colonne (selon la requête !)

                contact_entreprise = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                adresse_entreprise = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                libelle_satisfaction = reader.GetString(4);

                Console.WriteLine(siret + " : " + nom_entreprise + " , " + contact_entreprise + " , " + adresse_entreprise + " , " + libelle_satisfaction);

                Console.WriteLine();
            }
            reader.Close();
            #endregion

        }

        static void Fournisseur_modifie_fournit()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region affichage pièces fournisseur

            string no_piece;
            string siret;


            string answer;
            string new_value;
            Console.WriteLine("Veuillez renseigner votre siret");
            siret = Console.ReadLine();
            Console.WriteLine("Quelle pièce souhaitez-vous modifier?");
            no_piece = Console.ReadLine();

            Console.WriteLine("Que souhaitez-vous modifier?");
            Console.WriteLine("numéro de la pièce (N), prix de la pièce (P), delai (D)");
            answer = Console.ReadLine();
            Console.WriteLine("Rentrez sa nouvelle valeur");
            new_value = Console.ReadLine();
            //`fournit`(`no_piece`,`siret`,`prix_fournisseur_piece`,`delai_fournisseur_piece`)

            string update_fournit = "Update fournit set no_piece='" + no_piece + "' where siret='" + siret + "' and no_piece='" + no_piece + "';";
            switch (answer)
            {
                case "N":
                    update_fournit = "Update fournit set no_piece='" + new_value + "' where siret='" + siret + "' and no_piece='" + no_piece + "';";
                    break;
                case "P":
                    update_fournit = "Update fournit set prix_fournisseur_piece='" + Convert.ToInt32(new_value) + "' where siret='" + siret + "' and no_piece='" + no_piece + "';";
                    break;
                case "D":
                    update_fournit = "Update fournit set delai_fournisseur_piece='" + Convert.ToInt32(new_value) + "' where siret='" + siret + "' and no_piece='" + no_piece + "';";
                    break;
            }



            MySqlCommand command_update_fournisseur = maConnexion.CreateCommand();
            command_update_fournisseur.CommandText = update_fournit;

            try
            {
                command_update_fournisseur.ExecuteNonQuery();
                Console.WriteLine("Pièce mise à jour !");
                Console.WriteLine();
                string choice;
                Console.WriteLine("+ pour recommencer et - pour rejoindre le programme principal");
                choice = Console.ReadLine();
                if (choice == "+")
                {
                    Fournisseur_modifie_fournit();
                }
                if (choice == "-")
                {
                    MethodeG();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_update_fournisseur.Dispose();


            #endregion



        }

        static void Fournisseur_ajoute_fournit()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            //`velomax`.`fournit`(`no_piece`,`siret`,`prix_fournisseur_piece`,`delai_fournisseur_piece`)

            #region créer fournir
            // Attributs de la Table client_boutique
            MySqlParameter no_piece = new MySqlParameter("@no_piece", MySqlDbType.VarChar);
            MySqlParameter siret = new MySqlParameter("@siret", MySqlDbType.VarChar);
            MySqlParameter prix_fournisseur_piece = new MySqlParameter("@prix_fournisseur_piece", MySqlDbType.Int32);
            MySqlParameter delai_fournisseur_piece = new MySqlParameter("@delai_fournisseur_piece", MySqlDbType.Int32);

            Console.WriteLine("Ajouter une pièce à fournir : ");

            Console.WriteLine("--- Caractéristiques du client à CREER (si non défini écrire null)");
            Console.Write("Saisir le numéro de la pièce (e.g C32) : ");
            no_piece.Value = Console.ReadLine();

            Console.Write("Saisir le siret du fournisseur (e.g 36252186000034) :");
            siret.Value = Console.ReadLine();

            Console.Write("Saisir le prix de la pièce (e.g 5) : ");
            prix_fournisseur_piece.Value = Console.ReadLine();

            Console.Write("Saisir le délai de livraison (e.g 2) : ");
            delai_fournisseur_piece.Value = Console.ReadLine();


            string insertClient_Boutique = "INSERT INTO fournit  VALUES (@no_piece, @siret, @prix_fournisseur_piece, @delai_fournisseur_piece);";
            MySqlCommand command_insert_client_boutique = maConnexion.CreateCommand();
            command_insert_client_boutique.CommandText = insertClient_Boutique;

            command_insert_client_boutique.Parameters.Add(no_piece);
            command_insert_client_boutique.Parameters.Add(siret);
            command_insert_client_boutique.Parameters.Add(prix_fournisseur_piece);
            command_insert_client_boutique.Parameters.Add(delai_fournisseur_piece);

            try
            {
                command_insert_client_boutique.ExecuteNonQuery();
                Console.WriteLine("Pièce fournit crée !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                Console.WriteLine("Pièce déjà fournit");
                return;

            }
            command_insert_client_boutique.Dispose();
            #endregion
        }

        static void Fournisseur_supprime_fournit()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            //e.g C32 36252187900034
            #region Suppression Fournisseur

            MySqlParameter no_piece = new MySqlParameter("@no_piece", MySqlDbType.VarChar);
            MySqlParameter siret = new MySqlParameter("@siret", MySqlDbType.VarChar);

            Console.Write("Saisir le nom de la pièce à supprimer (e.g C32) : ");
            no_piece.Value = Console.ReadLine();
            Console.Write("Saisir le siret du fournisseur (e.g 36252186000034) :");
            siret.Value = Console.ReadLine();

            string suppFournisseur = "delete from fournit where siret=@siret and no_piece=@no_piece;";

            MySqlCommand command_supp_fournisseur = maConnexion.CreateCommand();
            command_supp_fournisseur.CommandText = suppFournisseur;

            command_supp_fournisseur.Parameters.Add(siret);
            command_supp_fournisseur.Parameters.Add(no_piece);

            try
            {
                command_supp_fournisseur.ExecuteNonQuery();
                Console.WriteLine("Pièce fournit supprimé !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;

            }
            command_supp_fournisseur.Dispose();

            #endregion


        }
        #endregion


        #region Méthodes du mode Démo

        static void AfficheNombreClients()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des pieces:");
            #region affichage nombre clients

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select count(*) from client_individuel;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            int nombre_clients_ind;
            List<int> clients = new List<int>();

            while (reader.Read())   // parcours ligne par ligne
            {
                nombre_clients_ind = reader.GetInt32(0);
                Console.WriteLine("Nombre de clients individuels: " + nombre_clients_ind);
                clients.Add(nombre_clients_ind);
            }
            reader.Close();

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = "select count(*) from client_boutique;";

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();
            int nombre_clients_bout;

            while (reader2.Read())   // parcours ligne par ligne
            {
                nombre_clients_bout = reader2.GetInt32(0);
                Console.WriteLine("Nombre de clients boutiques: " + nombre_clients_bout);
                clients.Add(nombre_clients_bout);
            }
            reader2.Close();

            Console.WriteLine("Nombre de clients au total: " + clients.Sum());
            #endregion


        }

        static void Clients_commande()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Clients et leurs commandes en cours 
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select nom_client,count(no_commande) from client_individuel join commande where commande.no_client=client_individuel.no_client;";
            Console.WriteLine("nom client/boutique : nombre de commandes en cours");
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string nom_client;
            int no_commande_client;

            while (reader.Read())   // parcours ligne par ligne
            {
                nom_client = reader.GetString(0);
                no_commande_client = reader.GetInt32(1);
                Console.WriteLine(nom_client + ": " + no_commande_client);
            }
            reader.Close();

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = "select commande.nom_compagnie,count(no_commande) from client_boutique join commande where commande.nom_compagnie=client_boutique.nom_compagnie;";

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();
            string nom_compagnie;
            int no_commande_compagnie;

            while (reader2.Read())   // parcours ligne par ligne
            {
                nom_compagnie = reader2.GetString(0);
                no_commande_compagnie = reader2.GetInt32(1);
                Console.WriteLine(nom_compagnie + ": " + no_commande_compagnie);
            }
            reader2.Close();
            #endregion
        }

        static void AffichePiceQuantite_inf2()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region affichage piece
            Console.WriteLine("Voici la liste des pieces dont le stock est inférieur à 2:");
            Console.WriteLine();
            Console.Write("--> ");
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select no_piece from piece where quantite_stock <= 2";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string num_piece;
            List<string> liste_pieces = new List<string>();


            while (reader.Read())   // parcours ligne par ligne
            {
                num_piece = reader.GetString(0);
                Console.Write(num_piece + ",");
                liste_pieces.Add(num_piece);

            }
            reader.Close();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Voici la liste des vélos dont l'assemblage nécessite ces pièces :");
            Console.WriteLine();
            Console.Write("--> ");
            string nom_velo;
            HashSet<string> liste_velos = new HashSet<string>();
            for (int i = 0; i < liste_pieces.Count; i++)
            {

                MySqlCommand command2 = maConnexion.CreateCommand();
                command2.CommandText = "select nom_bicyclette from assemblage where no_piece ='" + liste_pieces[i] + "' or no_piece_guidon='" + liste_pieces[i] + "' or no_piece_frein='" + liste_pieces[i] + "'or no_piece_selle='" + liste_pieces[i] + "'or no_piece_da='" + liste_pieces[i] + "'or no_piece_dr='" + liste_pieces[i] + "'or no_piece_roueav='" + liste_pieces[i] + "'or no_piece_rouear='" + liste_pieces[i] + "'or no_piece_reflecteurs='" + liste_pieces[i] + "'or no_piece_pedalier='" + liste_pieces[i] + "'or no_piece_ordinateur='" + liste_pieces[i] + "'or no_piece_panier='" + liste_pieces[i] + "';";

                MySqlDataReader reader2;
                reader2 = command2.ExecuteReader();

                while (reader2.Read())   // parcours ligne par ligne
                {
                    nom_velo = reader2.GetString(0);
                    liste_velos.Add(nom_velo);

                }
                reader2.Close();



            }

            foreach (string s in liste_velos)
            {
                Console.Write(s + ",");
            }

            Console.WriteLine();

            #endregion


        }

        static void Fournisseur_fournit()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region affichage piece

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select count(*),nom_entreprise from fournit join fournisseur on fournisseur.siret=fournit.siret  group by fournit.siret;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            int nombre_piece;
            string nom_entreprise;
            List<string> nom_des_entreprises = new List<string>();

            while (reader.Read())   // parcours ligne par ligne
            {
                nombre_piece = reader.GetInt32(0);
                nom_entreprise = reader.GetString(1);
                Console.WriteLine(nom_entreprise + ": " + nombre_piece + " pièces");
                nom_des_entreprises.Add(nom_entreprise);

            }
            reader.Close();
            Console.WriteLine();
            //nom des pièces que fournissent les fournisseurs avec le nom du fournisseur 
            List<string> pièces_du_fournisseur = new List<string>();
            string piece;
            for (int i = 0; i < nom_des_entreprises.Count; i++)
            {

                MySqlCommand command2 = maConnexion.CreateCommand();
                command2.CommandText = "select no_piece from fournit join fournisseur on fournisseur.siret=fournit.siret where nom_entreprise ='" + nom_des_entreprises[i] + "';";

                MySqlDataReader reader2;
                reader2 = command2.ExecuteReader();
                while (reader2.Read())   // parcours ligne par ligne
                {
                    piece = reader2.GetString(0);
                    pièces_du_fournisseur.Add(piece);
                }
                reader2.Close();


                string nom_velo;
                HashSet<string> liste_velos = new HashSet<string>();
                for (int j = 0; j < pièces_du_fournisseur.Count; j++)
                {

                    MySqlCommand command3 = maConnexion.CreateCommand();
                    command3.CommandText = "select nom_bicyclette from assemblage where no_piece ='" + pièces_du_fournisseur[j] + "' or no_piece_guidon='" + pièces_du_fournisseur[j] + "' or no_piece_frein='" + pièces_du_fournisseur[j] + "'or no_piece_selle='" + pièces_du_fournisseur[j] + "'or no_piece_da='" + pièces_du_fournisseur[j] + "'or no_piece_dr='" + pièces_du_fournisseur[j] + "'or no_piece_roueav='" + pièces_du_fournisseur[j] + "'or no_piece_rouear='" + pièces_du_fournisseur[j] + "'or no_piece_reflecteurs='" + pièces_du_fournisseur[j] + "'or no_piece_pedalier='" + pièces_du_fournisseur[j] + "'or no_piece_ordinateur='" + pièces_du_fournisseur[j] + "'or no_piece_panier='" + pièces_du_fournisseur[j] + "';";

                    MySqlDataReader reader3;
                    reader3 = command3.ExecuteReader();

                    while (reader3.Read())   // parcours ligne par ligne
                    {
                        nom_velo = reader3.GetString(0);
                        liste_velos.Add(nom_velo);

                    }
                    reader3.Close();



                }
                Console.Write(nom_des_entreprises[i] + ": ");
                foreach (string s in liste_velos)
                {

                    Console.Write(s + ",");
                }

                Console.WriteLine();
                Console.WriteLine();


            }

            #endregion

        }

        static void Export_XML()
        {//Export des stocks faibles avec fournisseurs pour commande en XML

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region export en xml
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = "select distinct nom_fournisseur from piece;";

            MySqlDataReader reader1;
            reader1 = command1.ExecuteReader();

            string nom_fournisseur;
            List<string> liste_fournisseurs = new List<string>();



            while (reader1.Read())   // parcours ligne par ligne
            {
                nom_fournisseur = reader1.GetString(0);
                liste_fournisseurs.Add(nom_fournisseur);

            }
            reader1.Close();


            XmlDocument docXml = new XmlDocument();

            // Création de l'élément racine... qu'on ajoute au document
            XmlElement racine = docXml.CreateElement("XML");
            docXml.AppendChild(racine);

            // création de l'en-tête XML (no <=> pas de DTD associée)
            XmlDeclaration xmldecl = docXml.CreateXmlDeclaration("1.0", "UTF-8", "no");
            docXml.InsertBefore(xmldecl, racine);



            foreach (string i in liste_fournisseurs)
            {

                MySqlCommand command = maConnexion.CreateCommand();
                command.CommandText = "select no_piece from piece where quantite_stock <= 2 and nom_fournisseur ='" + i + "';";

                MySqlDataReader reader;
                reader = command.ExecuteReader();
                string num_piece;

                List<string> liste_pieces = new List<string>();
                XmlElement Element = docXml.CreateElement("Element");
                racine.AppendChild(Element);

                XmlElement fournisseur = docXml.CreateElement("fournisseur");
                fournisseur.InnerText = i;
                Element.AppendChild(fournisseur);

                while (reader.Read())   // parcours ligne par ligne
                {
                    num_piece = reader.GetString(0);
                    //Console.Write(num_piece + ",");
                    liste_pieces.Add(num_piece);
                    XmlElement piece = docXml.CreateElement("piece");
                    piece.InnerText = num_piece;
                    Element.AppendChild(piece);

                }
                reader.Close();
                Console.WriteLine();


            }


            // enregistrement du document XML   ==> à retrouver dans le dossier bin\Debug de Visual Studio
            docXml.Save("bd1.xml");
            Console.WriteLine("fichier bd1.xml créé");


            #endregion
        }

        static void Export_JSON()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Recolte Infos
            Console.WriteLine("ecriture de Programme_fidelite_2mois.json\n-----------------------");
            string monFichier = "Programme_fidelite_2mois.json";

            //instanciation des "writer"
            StreamWriter writer = new StreamWriter(monFichier);
            JsonTextWriter jwriter = new JsonTextWriter(writer);

            //debut du fichier Json
            jwriter.WriteStartObject();




            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = "select distinct nom_client,prenom_client from client_individuel  join adhere on adhere.no_client = client_individuel.no_client join fidelio on fidelio.no_fidelio = adhere.no_fidelio where datediff(now(), date_paiement)< 56;";

            MySqlDataReader reader1;
            reader1 = command1.ExecuteReader();

            string nom_client = "";
            //List<string> les_noms_clients = new List<string>();
            string[] les_noms_clients = new string[reader1.FieldCount];
            string prenom_client = "";
            string[] les_prenoms_clients = new string[reader1.FieldCount];
            int counter = 0;
            //Noms et Prénoms des clients dont le programme de fidélité arrive à expiration dans moins de 2 mois 
            while (reader1.Read())   // parcours ligne par ligne
            {
                nom_client = reader1.GetString(0); // récupération 1ère colonne (selon la requête !)
                les_noms_clients[counter] = nom_client;
                prenom_client = reader1.GetString(1); // récupération 2ème colonne (selon la requête !)
                les_prenoms_clients[counter] = prenom_client;
                counter++;
            }
            reader1.Close();

            string description_fidelio = "";
            List<string> les_description_fidelio = new List<string>();

            MySqlCommand command = maConnexion.CreateCommand();

            jwriter.WritePropertyName("Clients");
            jwriter.WriteStartArray();

            for (int i = 0; i <= les_noms_clients.Length - 1; i++)
            {
                jwriter.WriteStartObject();
                jwriter.WritePropertyName("nom");
                jwriter.WriteValue(les_noms_clients[i]);

                jwriter.WritePropertyName("prenom");
                jwriter.WriteValue(les_prenoms_clients[i]);

                command.CommandText = "select distinct description_fidelio from client_individuel join adhere on adhere.no_client = client_individuel.no_client join fidelio on fidelio.no_fidelio = adhere.no_fidelio where nom_client='" + les_noms_clients[i] + "' and prenom_client='" + les_prenoms_clients[i] + "';";
                MySqlDataReader reader2;
                reader2 = command.ExecuteReader();
                while (reader2.Read())   // parcours ligne par ligne
                {

                    description_fidelio = reader2.GetString(0);
                    les_description_fidelio.Add(description_fidelio);
                    jwriter.WritePropertyName("Programme fidelio");
                    jwriter.WriteValue(description_fidelio);

                }
                reader2.Close();

                jwriter.WriteEndObject();
            }

            jwriter.WriteEndArray();
            jwriter.WriteEndObject();

            //fermeture de "writer"
            jwriter.Close();
            writer.Close();



            #endregion



        }

        #endregion


        #region Methodes Requetes "Originales"

        static void Requete_synchronise()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region affichage pièces rentables
            Console.WriteLine("Voici la liste des pièces qui sont produites depuis le plus de temps sur le marchés :");

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = " select V.no_piece,V.description_piece from piece V where datediff(date_discontinuation_piece,date_intro_piece)> ( SELECT avg (datediff(date_discontinuation_piece,date_intro_piece)) FROM piece V1 where V1.description_piece=V.description_piece ) order by V.description_piece;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string no_piece;
            string description_piece;

            while (reader.Read())   // parcours ligne par ligne
            {
                no_piece = reader.GetString(0);
                description_piece = reader.GetString(1);

                Console.WriteLine(description_piece + " : " + no_piece);

            }
            reader.Close();


            #endregion



        }

        static void Requete_auto_jointure()
        {
            //AutoJointure SELECT P1.nom, P2.nom FROM Producteur P1, Producteur P2 WHERE P1.region = P2.region AND P1.nom < P2.nom;
            //Select siret,nom_entreprise from fournisseur;
            //
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Pièces en commun
            Console.WriteLine("Voici les pièces fournis par plusieurs fournisseurs, les fournisseurs sont groupés 2 à 2 :");
            Console.WriteLine();
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select distinct f1.no_piece,f1.siret,f2.siret from fournit f1 ,fournit f2 where f1.no_piece=f2.no_piece and f1.siret < f2.siret order by f1.siret,f2.siret ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string no_piece;
            string siret1;
            string siret2;
            string nom_entreprise1 = "";
            string nom_entreprise2 = "";

            while (reader.Read())   // parcours ligne par ligne
            {
                no_piece = reader.GetString(0);
                siret1 = reader.GetString(1);
                siret2 = reader.GetString(2);
                if (siret1 == "34536187900034")
                {
                    nom_entreprise1 = "Stuff";
                }
                if (siret2 == "34536187900034")
                {
                    nom_entreprise2 = "Stuff";
                }

                if (siret1 == "34536197900034")
                {
                    nom_entreprise1 = "Bicloune";
                }
                if (siret2 == "34536197900034")
                {
                    nom_entreprise2 = "Bicloune";
                }

                if (siret1 == "36252187900034")
                {
                    nom_entreprise1 = "Piking";
                }
                if (siret2 == "36252187900034")
                {
                    nom_entreprise2 = "Piking";
                }
                //Console.WriteLine(no_piece + ": " + nom_entreprise1 + " , " + nom_entreprise2);
                Console.WriteLine(nom_entreprise1 + " & " + nom_entreprise2 + ": " + no_piece);

            }
            reader.Close();
            #endregion
        }

        static void Requete_union()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Nombre de bicyclette dans les commandes
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "select count(*) from contient_bicyclette ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            int compte_bicyclette = 0;
            while (reader.Read())   // parcours ligne par ligne
            {
                compte_bicyclette = reader.GetInt32(0);
            }
            reader.Close();
            #endregion

            #region Nombre de piece dans les commandes
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = "select count(*) from contient_piece ;";

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();
            int compte_piece = 0;

            while (reader2.Read())   // parcours ligne par ligne
            {
                compte_piece = reader2.GetInt32(0);
            }
            reader2.Close();
            #endregion

            #region Vélos et bicyclettes en cours de commande
            int piece_tot = 0;
            piece_tot = compte_piece + compte_bicyclette;

            Console.WriteLine("Il y a " + piece_tot + " éléments en cours de commande");

            Console.WriteLine("");

            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = "select * from contient_bicyclette union select * from contient_piece  order by no_bicyclette  ;";
            string une_piece;
            MySqlDataReader reader3;
            reader3 = command3.ExecuteReader();
            List<string> velos = new List<string>();
            List<string> pieces = new List<string>();

            while (reader3.Read())   // parcours ligne par ligne
            {
                une_piece = reader3.GetString(1);
                if (une_piece.StartsWith("1"))
                {
                    velos.Add(une_piece);

                }
                else
                {
                    pieces.Add(une_piece);
                }

            }
            reader3.Close();
            Console.WriteLine("Liste des vélos :");
            for (int i = 0; i < velos.Count; i++)
            {
                Console.Write(velos[i] + "|");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Liste des pièces :");
            for (int i = 0; i < pieces.Count; i++)
            {
                Console.Write(pieces[i] + "|");
            }

            #endregion


        }

        #endregion


        #region Affichage de Pièces, Clients, Fournisseurs et commandes 

        static void AffichePieces()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des pieces:");
            #region affichage piece

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from piece";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string no_piece = "";
            string description_piece = "";
            string nom_fournisseur = "";
            string no_catalogue_fournisseur = "";
            string date_intro_piece = "";
            string date_discontinuation_piece = "";
            string quantite_stock = "";
            Console.WriteLine("no_piece|description_piece|nom_fournisseur|no_catalogue_fournisseur|date_intro_piece|date_discontinuation_piece|quantite_stock");
            while (reader.Read())   // parcours ligne par ligne
            {
                no_piece = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                description_piece = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                nom_fournisseur = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                no_catalogue_fournisseur = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                date_intro_piece = reader.GetString(4);
                date_discontinuation_piece = reader.GetString(5);
                quantite_stock = reader.GetString(6);

                Console.WriteLine(no_piece + " : " + description_piece + " , " + nom_fournisseur + " , " + no_catalogue_fournisseur + " , " + date_intro_piece + " , " + date_discontinuation_piece + "," + quantite_stock);

                Console.WriteLine();
            }
            reader.Close();
            #endregion


        }


        static void AfficheVelos()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des vélos:");
            #region affichage piece

            MySqlCommand command = maConnexion.CreateCommand();
            //`bicyclette` (`no_bicyclette`,`nom_bicyclette`,`grandeur_bicyclette`,`prix_bicyclette`,`no_modele`,`ligne_produit`) 
            command.CommandText = "Select * from bicyclette";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string no_bicyclette = "";
            string nom_bicyclette = "";
            string grandeur_bicyclette = "";
            string prix_bicyclette = "";
            string no_modele = "";
            string ligne_produit = "";

            Console.WriteLine("no_bicyclette|nom_bicyclette|nom_fournisseur|grandeur_bicyclette|prix_bicyclette|no_modele|ligne_produit");
            Console.WriteLine("");
            while (reader.Read())   // parcours ligne par ligne
            {
                no_bicyclette = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                nom_bicyclette = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                grandeur_bicyclette = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                prix_bicyclette = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                no_modele = reader.GetString(4);
                ligne_produit = reader.GetString(5);

                Console.WriteLine(no_bicyclette + " : " + nom_bicyclette + " , " + grandeur_bicyclette + " , " + prix_bicyclette + " , " + no_modele + " , " + ligne_produit);

                Console.WriteLine();
            }
            reader.Close();
            #endregion


        }
        
        static void AfficheClientsInd()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Clients Individuels:");
            #region affichage clients Individuels

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from client_individuel";
            //client_individuel`(`no_client`,`nom_client`,`prenom_client`,`adresse_client`,`tel_client`,`courriel_client`) 
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string no_client = "";
            string nom_client = "";
            string prenom_client = "";
            string adresse_client = "";
            string tel_client = "";
            string courriel_client = "";

            Console.WriteLine(" no_client|nom_client|prenom_client|adresse_client|tel_client|courriel_client");
            while (reader.Read())   // parcours ligne par ligne
            {
                no_client = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                nom_client = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                prenom_client = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                adresse_client = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                tel_client = reader.GetString(4);
                courriel_client = reader.GetString(5);

                Console.WriteLine(no_client + " : " + nom_client + " , " + prenom_client + " , " + adresse_client + " , " + tel_client + " , " + courriel_client);

                Console.WriteLine();
            }
            reader.Close();
            #endregion


        }

        static void AffichageClientsBout()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Clients Boutiques:");
            #region affichage clients boutique

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from client_boutique";
            //`client_boutique`(`tel_boutique`,`courriel_boutique`,`nom_contact_boutique`,`pourcentage_remise`) 
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string nom_compagnie = "";
            string adresse_boutique = "";
            string tel_boutique = "";
            string courriel_boutique = "";
            string nom_contact_boutique = "";
            string pourcentage_remise = "";
            Console.WriteLine("nom_compagnie|adresse_boutique|tel_boutique|courriel_boutique|nom_contact_boutique|pourcentage_remise");
            while (reader.Read())   // parcours ligne par ligne
            {
                nom_compagnie = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                adresse_boutique = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                tel_boutique = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                courriel_boutique = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                nom_contact_boutique = reader.GetString(4);
                pourcentage_remise = reader.GetString(5);

                Console.WriteLine(nom_compagnie + " : " + adresse_boutique + " , " + tel_boutique + " , " + courriel_boutique + " , " + nom_contact_boutique + " , " + pourcentage_remise);

                Console.WriteLine();
            }
            reader.Close();
            #endregion

        }

        static void AffichageFournisseurs()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Fournisseurs:");
            #region affichage fournisseurs

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from fournisseur";
            //`fournisseur`(`siret`,`nom_entreprise`,`contact_entreprise`,`adresse_entreprise`,`libelle_satisfaction`)
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string siret = "";
            string nom_entreprise = "";
            string contact_entreprise = "";
            string adresse_entreprise = "";
            string libelle_satisfaction = "";

            Console.WriteLine("siret|nom_entreprise|contact_entreprise|adresse_entreprise|libelle_satisfaction");
            while (reader.Read())   // parcours ligne par ligne
            {
                siret = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                nom_entreprise = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                contact_entreprise = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                adresse_entreprise = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                libelle_satisfaction = reader.GetString(4);

                Console.WriteLine(siret + " : " + nom_entreprise + " , " + contact_entreprise + " , " + adresse_entreprise + " , " + libelle_satisfaction);

                Console.WriteLine();
            }
            reader.Close();
            #endregion

        }

        static void AffichageCommandes()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Commandes:");
            #region affichage commande

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from commande";
            //`commande`(`no_commande`,`date_commande`,`adresse_livraison`,`date_livraison`,`nom_compagnie`,`no_client`) 
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string no_commande = "";
            string date_commande = "";
            string adresse_livraison = "";
            string date_livraison = "";
            string nom_compagnie = "";
            string no_client = "";
            Console.WriteLine("no_commande|date_commande|adresse_livraison|date_livraison|nom_compagnie|no_client");


            while (reader.Read())   // parcours ligne par ligne
            {
                no_commande = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                date_commande = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                adresse_livraison = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                date_livraison = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                if (!reader.IsDBNull(4))
                {
                    nom_compagnie = reader.GetString(4);
                }
                else
                {
                    nom_compagnie = "null";
                }
                if (!reader.IsDBNull(5))
                {
                    no_client = reader.GetString(5);
                }
                else
                {
                    no_client = "null";
                }


                Console.WriteLine(no_commande + " : " + date_commande + " , " + adresse_livraison + " , " + date_livraison + " , " + nom_compagnie + " , " + no_client);

                Console.WriteLine();
            }
            reader.Close();
            #endregion

        }

        static void AffichageContientPiece(string no_commande)
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Pièces de la commande:");
            #region affichage commande

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from contient_piece where no_commande='" + no_commande + "';";
            //`contient_piece`(`id_contient_piece`,`no_piece`,`no_commande`,`quantite_piece`)
            MySqlDataReader reader;
            reader = command.ExecuteReader();


            string id_contient_piece = "";
            string no_piece = "";
            string quantite_piece = "";

            Console.WriteLine("no_commande : id_contient_piece|no_piece|quantite_piece");


            while (reader.Read())   // parcours ligne par ligne
            {
                id_contient_piece = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                no_piece = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                //no_commande = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                quantite_piece = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)



                Console.WriteLine(no_commande + " : " + id_contient_piece + " , " + no_piece + " , " + quantite_piece);

                Console.WriteLine();
            }
            reader.Close();
            #endregion


        }

        static void AffichageContientBic(string no_commande)
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Bicyclettes de la commande:");
            #region affichage commande

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from contient_bicyclette where no_commande='" + no_commande + "';";
            //`contient_bicyclette`(`id_contient_bicyclette`,`no_bicyclette`,`no_commande`,`quantite_bicyclette`)
            MySqlDataReader reader;
            reader = command.ExecuteReader();


            string id_contient_bicyclette = "";
            string no_bicyclette = "";
            string quantite_bicyclette = "";

            Console.WriteLine("no_commande : id_contient_bicyclette|no_bicyclette|quantite_bicyclette");


            while (reader.Read())   // parcours ligne par ligne
            {
                id_contient_bicyclette = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                no_bicyclette = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                //no_commande = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                quantite_bicyclette = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)



                Console.WriteLine(no_commande + " : " + id_contient_bicyclette + " , " + no_bicyclette + " , " + quantite_bicyclette);

                Console.WriteLine();
            }
            reader.Close();
            #endregion


        }

        #endregion


        #region Affichage Pour Bozo

        static void AffichePieces_Bozo()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=bozo;PASSWORD=bozo";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des pieces:");
            #region affichage piece

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from piece";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string no_piece = "";
            string description_piece = "";
            string nom_fournisseur = "";
            string no_catalogue_fournisseur = "";
            string date_intro_piece = "";
            string date_discontinuation_piece = "";
            string quantite_stock = "";
            Console.WriteLine("no_piece|description_piece|nom_fournisseur|no_catalogue_fournisseur|date_intro_piece|date_discontinuation_piece|quantite_stock");
            while (reader.Read())   // parcours ligne par ligne
            {
                no_piece = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                description_piece = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                nom_fournisseur = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                no_catalogue_fournisseur = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                date_intro_piece = reader.GetString(4);
                date_discontinuation_piece = reader.GetString(5);
                quantite_stock = reader.GetString(6);

                Console.WriteLine(no_piece + " : " + description_piece + " , " + nom_fournisseur + " , " + no_catalogue_fournisseur + " , " + date_intro_piece + " , " + date_discontinuation_piece + "," + quantite_stock);

                Console.WriteLine();
            }
            reader.Close();
            #endregion


        }
        static void AfficheClientsInd_Bozo()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=bozo;PASSWORD=bozo";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Clients Individuels:");
            #region affichage clients Individuels

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from client_individuel";
            //client_individuel`(`no_client`,`nom_client`,`prenom_client`,`adresse_client`,`tel_client`,`courriel_client`) 
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string no_client = "";
            string nom_client = "";
            string prenom_client = "";
            string adresse_client = "";
            string tel_client = "";
            string courriel_client = "";

            Console.WriteLine(" no_client|nom_client|prenom_client|adresse_client|tel_client|courriel_client");
            while (reader.Read())   // parcours ligne par ligne
            {
                no_client = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                nom_client = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                prenom_client = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                adresse_client = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                tel_client = reader.GetString(4);
                courriel_client = reader.GetString(5);

                Console.WriteLine(no_client + " : " + nom_client + " , " + prenom_client + " , " + adresse_client + " , " + tel_client + " , " + courriel_client);

                Console.WriteLine();
            }
            reader.Close();
            #endregion


        }
        static void AffichageClientsBout_Bozo()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=bozo;PASSWORD=bozo";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Clients Boutiques:");
            #region affichage clients boutique

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from client_boutique";
            //`client_boutique`(`tel_boutique`,`courriel_boutique`,`nom_contact_boutique`,`pourcentage_remise`) 
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string nom_compagnie = "";
            string adresse_boutique = "";
            string tel_boutique = "";
            string courriel_boutique = "";
            string nom_contact_boutique = "";
            string pourcentage_remise = "";
            Console.WriteLine("nom_compagnie|adresse_boutique|tel_boutique|courriel_boutique|nom_contact_boutique|pourcentage_remise");
            while (reader.Read())   // parcours ligne par ligne
            {
                nom_compagnie = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                adresse_boutique = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                tel_boutique = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                courriel_boutique = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                nom_contact_boutique = reader.GetString(4);
                pourcentage_remise = reader.GetString(5);

                Console.WriteLine(nom_compagnie + " : " + adresse_boutique + " , " + tel_boutique + " , " + courriel_boutique + " , " + nom_contact_boutique + " , " + pourcentage_remise);

                Console.WriteLine();
            }
            reader.Close();
            #endregion

        }
        static void AffichageFournisseurs_Bozo()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=bozo;PASSWORD=bozo";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Fournisseurs:");
            #region affichage fournisseurs

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from fournisseur";
            //`fournisseur`(`siret`,`nom_entreprise`,`contact_entreprise`,`adresse_entreprise`,`libelle_satisfaction`)
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string siret = "";
            string nom_entreprise = "";
            string contact_entreprise = "";
            string adresse_entreprise = "";
            string libelle_satisfaction = "";

            Console.WriteLine("siret|nom_entreprise|contact_entreprise|adresse_entreprise|libelle_satisfaction");
            while (reader.Read())   // parcours ligne par ligne
            {
                siret = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                nom_entreprise = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                contact_entreprise = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                adresse_entreprise = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                libelle_satisfaction = reader.GetString(4);

                Console.WriteLine(siret + " : " + nom_entreprise + " , " + contact_entreprise + " , " + adresse_entreprise + " , " + libelle_satisfaction);

                Console.WriteLine();
            }
            reader.Close();
            #endregion

        }

        static void AffichageCommandes_Bozo()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=bozo;PASSWORD=bozo";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Commandes:");
            #region affichage commande

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from commande";
            //`commande`(`no_commande`,`date_commande`,`adresse_livraison`,`date_livraison`,`nom_compagnie`,`no_client`) 
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string no_commande = "";
            string date_commande = "";
            string adresse_livraison = "";
            string date_livraison = "";
            string nom_compagnie = "";
            string no_client = "";
            Console.WriteLine("no_commande|date_commande|adresse_livraison|date_livraison|nom_compagnie|no_client");


            while (reader.Read())   // parcours ligne par ligne
            {
                no_commande = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                date_commande = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                adresse_livraison = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                date_livraison = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                if (!reader.IsDBNull(4))
                {
                    nom_compagnie = reader.GetString(4);
                }
                else
                {
                    nom_compagnie = "null";
                }
                if (!reader.IsDBNull(5))
                {
                    no_client = reader.GetString(5);
                }
                else
                {
                    no_client = "null";
                }


                Console.WriteLine(no_commande + " : " + date_commande + " , " + adresse_livraison + " , " + date_livraison + " , " + nom_compagnie + " , " + no_client);

                Console.WriteLine();
            }
            reader.Close();
            #endregion

        }

        static void AffichageContientPiece_Bozo(string no_commande)
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=bozo;PASSWORD=bozo";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Pièces de la commande:");
            #region affichage commande

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from contient_piece where no_commande='" + no_commande + "';";
            //`contient_piece`(`id_contient_piece`,`no_piece`,`no_commande`,`quantite_piece`)
            MySqlDataReader reader;
            reader = command.ExecuteReader();


            string id_contient_piece = "";
            string no_piece = "";
            string quantite_piece = "";

            Console.WriteLine("no_commande : id_contient_piece|no_piece|quantite_piece");


            while (reader.Read())   // parcours ligne par ligne
            {
                id_contient_piece = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                no_piece = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                //no_commande = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                quantite_piece = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)



                Console.WriteLine(no_commande + " : " + id_contient_piece + " , " + no_piece + " , " + quantite_piece);

                Console.WriteLine();
            }
            reader.Close();
            #endregion


        }

        static void AffichageContientBic_Bozo(string no_commande)
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=bozo;PASSWORD=bozo";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            Console.WriteLine("Voici la liste des Bicyclettes de la commande:");
            #region affichage commande

            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = "Select * from contient_bicyclette where no_commande='" + no_commande + "';";
            //`contient_bicyclette`(`id_contient_bicyclette`,`no_bicyclette`,`no_commande`,`quantite_bicyclette`)
            MySqlDataReader reader;
            reader = command.ExecuteReader();


            string id_contient_bicyclette = "";
            string no_bicyclette = "";
            string quantite_bicyclette = "";

            Console.WriteLine("no_commande : id_contient_bicyclette|no_bicyclette|quantite_bicyclette");


            while (reader.Read())   // parcours ligne par ligne
            {
                id_contient_bicyclette = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                no_bicyclette = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                //no_commande = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                quantite_bicyclette = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)



                Console.WriteLine(no_commande + " : " + id_contient_bicyclette + " , " + no_bicyclette + " , " + quantite_bicyclette);

                Console.WriteLine();
            }
            reader.Close();
            #endregion


        }



        #endregion


        #region Création  de Pièces, Clients, Fournisseurs et commandes 

        static void CreaPieces()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Ajout Quantite / Creation et Insertion pieces
            Console.WriteLine("--- Ajout Quantite / Creation et Insertion de pieces");

            // Attributs de la Table PIECE
            MySqlParameter no_piece = new MySqlParameter("@no_piece", MySqlDbType.VarChar);
            MySqlParameter description_piece = new MySqlParameter("@description_piece", MySqlDbType.VarChar);
            MySqlParameter nom_fournisseur = new MySqlParameter("@nom_fournisseur", MySqlDbType.VarChar);
            MySqlParameter no_catalogue_fournisseur = new MySqlParameter("@no_catalogue_fournisseur", MySqlDbType.VarChar);
            MySqlParameter date_intro_piece = new MySqlParameter("@date_intro_piece", MySqlDbType.DateTime);
            MySqlParameter date_discontinuation_piece = new MySqlParameter("@date_discontinuation_piece", MySqlDbType.DateTime);
            MySqlParameter quantite_stock = new MySqlParameter("@quantite_stock", MySqlDbType.Int32);

            Console.Write("Voulez-vous AJOUTER une pièce au stock ou en CREER une nouvelle ? (A ou C) : ");
            string action = Console.ReadLine();

            // Ajout piece deja existante -> incrementation du stock
            if (action == "A")
            {
                Console.Write("Saisir le numéro de la pièce à ajouter (e.g C32) : ");
                no_piece.Value = Console.ReadLine();
                Console.Write("Saisir le nom du fournisseur de la pièce à ajouter (e.g Stuff) : ");
                nom_fournisseur.Value = Console.ReadLine();

                string requeteAjout = "SELECT * FROM piece WHERE no_piece = @no_piece AND nom_fournisseur = @nom_fournisseur;";
                MySqlCommand commandAjout = maConnexion.CreateCommand();
                commandAjout.CommandText = requeteAjout;
                commandAjout.Parameters.Add(no_piece);
                commandAjout.Parameters.Add(nom_fournisseur);
                MySqlDataReader readerAjout = commandAjout.ExecuteReader();

                Console.WriteLine("Voici les caractéristiques de la pièce :");
                string[] valueStringAjout = new string[readerAjout.FieldCount];
                while (readerAjout.Read())
                {
                    for (int i = 0; i < readerAjout.FieldCount - 1; i++)
                    {
                        valueStringAjout[i] = readerAjout.GetValue(i).ToString();
                        Console.Write(valueStringAjout[i] + " | ");
                    }
                    Console.WriteLine(readerAjout.GetValue(readerAjout.FieldCount).ToString());
                }
                readerAjout.Close();

                Console.Write("Quelle QUANTITE de cette pièce voulez-vous ajouter ? (e.g 2) : ");
                quantite_stock.Value = Console.ReadLine();

                #region Update Quantite
                string UpdateQuantite = "UPDATE piece SET quantite_stock = @quantite_stock WHERE no_piece = @no_piece AND nom_fournisseur = @nom_fournisseur;";
                MySqlCommand command_update_quantite = maConnexion.CreateCommand();
                command_update_quantite.CommandText = UpdateQuantite;
                command_update_quantite.Parameters.Add(no_piece);
                command_update_quantite.Parameters.Add(nom_fournisseur);
                command_update_quantite.Parameters.Add(quantite_stock);
                try
                {
                    command_update_quantite.ExecuteNonQuery();
                    Console.WriteLine("Quantite modifié !");
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(" ErreurUpdate : " + e.ToString());
                    Console.ReadLine();
                    return;
                }
                command_update_quantite.Dispose();
                #endregion

            }

            // Creation et Insertion d'une nouvelle piece
            else
            {
                Console.WriteLine("--- Caractéristiques de la pièce a CREER (si non défini écrire null)");
                Console.Write("Saisir le numéro de la pièce à créer (e.g C32) : ");
                no_piece.Value = Console.ReadLine();
                Console.Write("Saisir la description de la pièce à créer (e.g Cadre) : ");
                description_piece.Value = Console.ReadLine();
                Console.Write("Saisir le nom du fournisseur de la pièce à créer (e.g Stuff) : ");
                nom_fournisseur.Value = Console.ReadLine();
                Console.Write("Saisir le numero du catalogue du fournisseur de la pièce à créer (e.g 6) : ");
                no_catalogue_fournisseur.Value = Console.ReadLine();
                Console.Write("Saisir la date d'introduction de la pièce à créer (e.g 2000-11-05) : ");
                date_intro_piece.Value = Console.ReadLine();
                Console.Write("Saisir la date de discontinuation de la pièce à créer (e.g 2012-07-20) : ");
                date_discontinuation_piece.Value = Console.ReadLine();
                Console.Write("Saisir la quantité de la pièce à créer (e.g 4) : ");
                quantite_stock.Value = Console.ReadLine();

                #region Insert piece
                string insertPiece = "INSERT INTO piece VALUES (@no_piece, @description_piece, @nom_fournisseur, @no_catalogue_fournisseur, @date_intro_piece, @date_discontinuation_piece, @quantite_stock);";
                MySqlCommand command_insert_piece = maConnexion.CreateCommand();
                command_insert_piece.CommandText = insertPiece;
                command_insert_piece.Parameters.Add(no_piece);
                command_insert_piece.Parameters.Add(description_piece);
                command_insert_piece.Parameters.Add(nom_fournisseur);
                command_insert_piece.Parameters.Add(no_catalogue_fournisseur);
                command_insert_piece.Parameters.Add(date_intro_piece);
                command_insert_piece.Parameters.Add(date_discontinuation_piece);
                command_insert_piece.Parameters.Add(quantite_stock);
                try
                {
                    command_insert_piece.ExecuteNonQuery();
                    Console.WriteLine("Pièce créée !");
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(" ErreurInsert : " + e.ToString());
                    Console.ReadLine();
                    return;
                }
                command_insert_piece.Dispose();
                #endregion
            }
            #endregion
        }

        static void CreaAdhere()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion
            Console.WriteLine("Voici la liste des programmes Fidelio:");


            #region  On lie client et fidelio via adhere 
            MySqlParameter no_client = new MySqlParameter("@no_client", MySqlDbType.Int32);
            MySqlParameter no_fidelio = new MySqlParameter("@no_fidelio", MySqlDbType.Int32);
            MySqlParameter date_adhesion = new MySqlParameter("@date_adhesion", MySqlDbType.DateTime);
            MySqlParameter date_paiement = new MySqlParameter("@date_paiement", MySqlDbType.DateTime);


            Console.WriteLine("Validez le numero du client ?");
            no_client.Value = Console.ReadLine();
            Console.WriteLine("A quel programme Fidelio Souhaitez vous enregistrer le client ?");
            no_fidelio.Value = Console.ReadLine();
            Console.WriteLine("A quel date d'adhesion Souhaitez vous enregistrer le client ?");
            date_adhesion.Value = Console.ReadLine();
            Console.WriteLine("A quel date de paiement Souhaitez vous enregistrer le client ?");
            date_paiement.Value = Console.ReadLine();


            string Client_to_fidelio = "INSERT INTO adhere VALUES (@no_client, @no_fidelio, @date_adhesion , @date_paiement );";

            MySqlCommand command_insert_client_to_fidelio = maConnexion.CreateCommand();
            command_insert_client_to_fidelio.CommandText = Client_to_fidelio;

            command_insert_client_to_fidelio.Parameters.Add(no_client);
            command_insert_client_to_fidelio.Parameters.Add(no_fidelio);
            command_insert_client_to_fidelio.Parameters.Add(date_adhesion);
            command_insert_client_to_fidelio.Parameters.Add(date_paiement);

            try
            {
                command_insert_client_to_fidelio.ExecuteNonQuery();
                Console.WriteLine("Client lié avec Fidelio!");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }

            command_insert_client_to_fidelio.Dispose();
            #endregion

        } //Methode utilisé dans CreaClients, ne pas executer seul

        static void CreaClientsInd()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Création de clients particuliers avec ou sans prgm Fidelio
            //`velomax`.`client_individuel`(`no_client`,`nom_client`,`prenom_client`,`adresse_client`,`tel_client`,`courriel_client`)
            Console.WriteLine("--- Création de clients particuliers avec ou sans prgm Fidelio");

            // Attributs de la Table client_individuel
            MySqlParameter no_client = new MySqlParameter("@no_client", MySqlDbType.Int32);
            MySqlParameter nom_client = new MySqlParameter("@nom_client", MySqlDbType.VarChar);
            MySqlParameter prenom_client = new MySqlParameter("@prenom_client", MySqlDbType.VarChar);
            MySqlParameter adresse_client = new MySqlParameter("@adresse_client", MySqlDbType.VarChar);
            MySqlParameter tel_client = new MySqlParameter("@tel_client", MySqlDbType.VarChar);
            MySqlParameter courriel_client = new MySqlParameter("@courriel_client", MySqlDbType.VarChar);

            Console.WriteLine("Ajouter un client : ");

            Console.WriteLine("--- Caractéristiques du client à CREER (si non défini écrire null)");

            Console.Write("Saisir le nom du client à créer :(e.g Delon) ");
            nom_client.Value = Console.ReadLine();
            Console.Write("Saisir le prénom du client à créer (e.g Estelle) : ");
            prenom_client.Value = Console.ReadLine();
            Console.Write("Saisir l'adresse du client à créer (e.g 1 avenue des Roses, 75006 Paris) : ");
            adresse_client.Value = Console.ReadLine();
            Console.Write("Saisir le numero de téléphone du client à créer (e.g 0644782435) : ");
            tel_client.Value = Console.ReadLine();
            Console.Write("Saisir l'adresse mail du client à créer (e.g Estelle.Delon@gmail.fr) : ");
            courriel_client.Value = Console.ReadLine();

            string insertClient = "INSERT INTO client_individuel  VALUES (null, @nom_client, @prenom_client, @adresse_client, @tel_client, @courriel_client);";
            MySqlCommand command_insert_client = maConnexion.CreateCommand();
            command_insert_client.CommandText = insertClient;

            command_insert_client.Parameters.Add(nom_client);
            command_insert_client.Parameters.Add(prenom_client);
            command_insert_client.Parameters.Add(adresse_client);
            command_insert_client.Parameters.Add(tel_client);
            command_insert_client.Parameters.Add(courriel_client);
            try
            {
                command_insert_client.ExecuteNonQuery();
                Console.WriteLine("Client créée !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_insert_client.Dispose();



            Console.Write("Ajouter un client avec ou sans programme fidélio ? (A ou S): ");
            string action = Console.ReadLine();
            if (action == "A")
            {
                Console.WriteLine("Voici la liste des programmes Fidelio:");
                #region affichage fidelio
                MySqlCommand command = maConnexion.CreateCommand();
                command.CommandText = "Select * from fidelio";

                MySqlDataReader reader;
                reader = command.ExecuteReader();

                string no_fidelio = "";
                string description_fidelio = "";
                string cout_fidelio = "";
                string duree_fidelio = "";
                string rabais_fidelio = "";

                while (reader.Read())   // parcours ligne par ligne
                {
                    no_fidelio = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                    description_fidelio = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                    cout_fidelio = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                    duree_fidelio = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)
                    rabais_fidelio = reader.GetString(4);

                    Console.WriteLine(no_fidelio + " : " + description_fidelio + " , " + cout_fidelio + " , " + duree_fidelio + " , " + rabais_fidelio);

                    Console.WriteLine();
                }
                reader.Close();
                #endregion

                #region  On lie client et fidelio via adhere 
                CreaAdhere();
                #endregion
            }




            #endregion
        }

        static void CreaClientsBout()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Création de clients Boutique
            //`velomax`.`client_boutique`(`nom_compagnie`,`adresse_boutique`,`tel_boutique`,`courriel_boutique`,`nom_contact_boutique`,`pourcentage_remise`) 
            Console.WriteLine("--- Création de clients Boutiques");

            // Attributs de la Table client_boutique
            MySqlParameter nom_compagnie = new MySqlParameter("@nom_compagnie", MySqlDbType.VarChar);
            MySqlParameter adresse_boutique = new MySqlParameter("@adresse_boutique", MySqlDbType.VarChar);
            MySqlParameter tel_boutique = new MySqlParameter("@tel_boutique", MySqlDbType.VarChar);
            MySqlParameter courriel_boutique = new MySqlParameter("@courriel_boutique", MySqlDbType.VarChar);
            MySqlParameter nom_contact_boutique = new MySqlParameter("@nom_contact_boutique", MySqlDbType.VarChar);
            MySqlParameter pourcentage_remise = new MySqlParameter("@pourcentage_remise", MySqlDbType.Float);

            Console.WriteLine("Ajouter un client boutique : ");

            Console.WriteLine("--- Caractéristiques du client à CREER (si non défini écrire null)");
            Console.Write("Saisir le nom de l'entreprise cliente (e.g 3) : ");
            nom_compagnie.Value = Console.ReadLine();
            Console.Write("Saisir l'adresse de l'entreprise cliente (e.g Delon) :");
            adresse_boutique.Value = Console.ReadLine();
            Console.Write("Saisir le numéro de téléphone de l'entreprise cliente (e.g 0644127845) : ");
            tel_boutique.Value = Console.ReadLine();
            Console.Write("Saisir l'adresse mail de l'entreprise cliente (e.g adresse.entreprise@hotmail.com) : ");
            courriel_boutique.Value = Console.ReadLine();
            Console.Write("Saisir le nom du contact direct de l'entreprise (e.g Paul Thomas) : ");
            nom_contact_boutique.Value = Console.ReadLine();
            Console.Write("Saisir le pourcentage de remise, écrire 0 ou null si aucun, ce dernier sera verifié : ");
            pourcentage_remise.Value = Console.ReadLine();

            string insertClient_Boutique = "INSERT INTO client_boutique  VALUES (@nom_compagnie, @adresse_boutique, @tel_boutique, @courriel_boutique, @nom_contact_boutique, @pourcentage_remise);";
            MySqlCommand command_insert_client_boutique = maConnexion.CreateCommand();
            command_insert_client_boutique.CommandText = insertClient_Boutique;
            command_insert_client_boutique.Parameters.Add(nom_compagnie);
            command_insert_client_boutique.Parameters.Add(adresse_boutique);
            command_insert_client_boutique.Parameters.Add(tel_boutique);
            command_insert_client_boutique.Parameters.Add(courriel_boutique);
            command_insert_client_boutique.Parameters.Add(nom_contact_boutique);
            command_insert_client_boutique.Parameters.Add(pourcentage_remise);
            try
            {
                command_insert_client_boutique.ExecuteNonQuery();
                Console.WriteLine("Client Boutique créée !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_insert_client_boutique.Dispose();
            #endregion
        }

        static void CreaFournisseurs()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region Création de Fournisseurs 
            //`velomax`.`fournisseur`(`siret`,`nom_entreprise`,`contact_entreprise`,`adresse_entreprise`,`libelle_satisfaction`) 
            Console.WriteLine("--- Création de fournisseurs");

            // Attributs de la Table fournisseur
            MySqlParameter siret = new MySqlParameter("@siret", MySqlDbType.VarChar);
            MySqlParameter nom_entreprise = new MySqlParameter("@nom_entreprise", MySqlDbType.VarChar);
            MySqlParameter contact_entreprise = new MySqlParameter("@contact_entreprise", MySqlDbType.VarChar);
            MySqlParameter adresse_entreprise = new MySqlParameter("@adresse_entreprise", MySqlDbType.VarChar);
            MySqlParameter libelle_satisfaction = new MySqlParameter("@libelle_satisfaction", MySqlDbType.Int32);

            Console.WriteLine("Ajouter un fournisseur : ");

            Console.WriteLine("--- Caractéristiques du fournisseur à CREER (si non défini écrire null)");

            Console.Write("Saisir le siret du fournisseur à créer (e.g 36252187900034) : ");
            siret.Value = Console.ReadLine();
            Console.Write("Saisir le nom du fournisseur à créer :(e.g VeloMega) ");
            nom_entreprise.Value = Console.ReadLine();
            Console.Write("Saisir  le nom du countact du fournisseur à créer (e.g Estelle) : ");
            contact_entreprise.Value = Console.ReadLine();
            Console.Write("Saisir l'adresse du fournisseur (e.g 1 avenue des Roses, 75006 Paris) : ");
            adresse_entreprise.Value = Console.ReadLine();
            Console.Write("Saisir le libelle de satisfaction (e.g 1 très bon, 2 bon, 3 moyen, 4 mauvais, si non attribué: écrire 0) : ");
            Console.Write("Attention le libelle sera verifié");
            libelle_satisfaction.Value = Console.ReadLine();

            string insertFournisseur = "INSERT INTO fournisseur  VALUES (@siret, @nom_entreprise, @contact_entreprise, @adresse_entreprise, @libelle_satisfaction);";
            MySqlCommand command_insert_fournisseur = maConnexion.CreateCommand();
            command_insert_fournisseur.CommandText = insertFournisseur;
            command_insert_fournisseur.Parameters.Add(siret);
            command_insert_fournisseur.Parameters.Add(nom_entreprise);
            command_insert_fournisseur.Parameters.Add(contact_entreprise);
            command_insert_fournisseur.Parameters.Add(adresse_entreprise);
            command_insert_fournisseur.Parameters.Add(libelle_satisfaction);
            try
            {
                command_insert_fournisseur.ExecuteNonQuery();
                Console.WriteLine("Fournisseur crée !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_insert_fournisseur.Dispose();
            #endregion
        }


        static void CreaCommandes()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Création des Commandes 
            //`velomax`.`commande`(`no_commande`,`date_commande`,`adresse_livraison`,`date_livraison`,`nom_compagnie`,`no_client`)  
            Console.WriteLine("--- Création de commandes");

            // Attributs de la Table Commande
            string no_commande;
            MySqlParameter date_commande = new MySqlParameter("@date_commande", MySqlDbType.DateTime);
            MySqlParameter adresse_livraison = new MySqlParameter("@adresse_livraison", MySqlDbType.VarChar);
            MySqlParameter date_livraison = new MySqlParameter("@date_livraison", MySqlDbType.DateTime);

            string nom_compagnie;

            string lecture_no_client;
            Console.WriteLine("Ajouter une commande : ");

            Console.WriteLine("--- Caractéristiques de la commande à CREER (si non défini écrire null)");

            Console.Write("Saisir le numéro de la commande à créer (e.g 10) : ");
            no_commande = Console.ReadLine();
            Console.Write("Saisir la date d'aujourdhui, date de la commande (e.g 2000-01-01) :");
            date_commande.Value = Console.ReadLine();
            Console.Write("Saisir  l'adresse de la livraison  (e.g 1 avenue des pres) : ");
            adresse_livraison.Value = Console.ReadLine();
            Console.Write("Saisir la date de livraison (e.g 2000-01-01) : ");
            date_livraison.Value = Console.ReadLine();
            Console.Write("Saisir le nom de l'entreprise si client Boutique (e.g Veloworld) : ");
            nom_compagnie = Console.ReadLine();
            Console.Write("Saisir le numéro de l'acheteur si client Individuel (e.g 1) : ");
            lecture_no_client = Console.ReadLine();

            string insertCommande;
            if (lecture_no_client == "null")
            {
                insertCommande = "INSERT INTO commande VALUES ('" + no_commande + "', @date_commande, @adresse_livraison, @date_livraison,'" + nom_compagnie + "',null);";
            }
            else
            {

                insertCommande = "INSERT INTO commande VALUES ('" + no_commande + "', @date_commande, @adresse_livraison, @date_livraison,null,'" + lecture_no_client + "');";
            }



            MySqlCommand command_insert_commande = maConnexion.CreateCommand();
            command_insert_commande.CommandText = insertCommande;
            command_insert_commande.Parameters.Add(date_commande);
            command_insert_commande.Parameters.Add(adresse_livraison);
            command_insert_commande.Parameters.Add(date_livraison);

            try
            {
                command_insert_commande.ExecuteNonQuery();
                Console.WriteLine("Commande créée !");
                string directory;
                int quantite;
                Console.WriteLine("Votre commande comporte-t-elle des pièces(P), des vélos(V) ou les deux(PV)?");
                directory = Console.ReadLine();

                switch (directory)
                {
                    case "P":
                        Console.WriteLine("Combient de pièces voulez-vous ajouter ?");
                        quantite = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < quantite; i++)
                        {
                            Commande_contient_piece(no_commande);

                        }

                        break;

                    case "V":
                        Console.WriteLine("Combient de bicyclette voulez-vous ajouter ?");
                        quantite = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < quantite; i++)
                        {
                            Commande_contient_bicyclette(no_commande);
                        }

                        break;

                    case "PV":
                        Console.WriteLine("Combient de pièces voulez-vous ajouter ?");
                        quantite = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < quantite; i++)
                        {
                            Commande_contient_piece(no_commande);
                        }
                        Console.WriteLine("Combient de bicyclette voulez-vous ajouter ?");
                        quantite = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < quantite; i++)
                        {
                            Commande_contient_bicyclette(no_commande);
                        }

                        break;
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_insert_commande.Dispose();
            #endregion
        }

        static void Commande_contient_piece(string no_commande)
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region commande piece
            Console.WriteLine("Vous créez une pièce dans votre commande" + no_commande);
            Console.WriteLine();
            AffichageCommandes();
            //.`contient_piece`(`id_contient_piece`,`no_piece`,`no_commande`,`quantite_piece`)
            string no_piece;
            int quantite_piece;

            Console.WriteLine("Quelle est le numero de la pièce?");
            no_piece = Console.ReadLine();
            Console.WriteLine("Quelle est la quantite de la pièce?");
            quantite_piece = Convert.ToInt32(Console.ReadLine());

            string insertCommandepiece = "INSERT INTO contient_piece VALUES(null,'" + no_piece + "','" + no_commande + "'," + quantite_piece + ");";

            MySqlCommand command_insert_commande_piece = maConnexion.CreateCommand();
            command_insert_commande_piece.CommandText = insertCommandepiece;

            try
            {
                command_insert_commande_piece.ExecuteNonQuery();
                Console.WriteLine("Pièce lié à la commande crée !");
                Commande_modif_stock_piece(1, no_commande, no_piece);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_insert_commande_piece.Dispose();
            #endregion
        }

        static void Commande_contient_bicyclette(string no_commande)
        {
            //`contient_bicyclette`(`id_contient_bicyclette`,`no_bicyclette`,`no_commande`,`quantite_bicyclette`)
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region commande Bicyclette
            Console.WriteLine("Vous créez une bicyclette dans votre commande" + no_commande);
            AffichageCommandes();
            //.`contient_bicyclette`(`id_contient_bicyclette`,`no_bicyclette`,`no_commande`,`quantite_bicyclette`)

            string no_bicyclette;
            int quantite_bicyclette;

            Console.WriteLine("Quelle est le numero de la bicyclette?");
            no_bicyclette = Console.ReadLine();

            Console.WriteLine("Quelle est la quantite de la bicyclette?");
            quantite_bicyclette = Convert.ToInt32(Console.ReadLine());

            string insertCommandebicyclette = "INSERT INTO contient_bicyclette VALUES(null,'" + no_bicyclette + "','" + no_commande + "'," + quantite_bicyclette + ");";

            MySqlCommand command_insert_commande_bicyclette = maConnexion.CreateCommand();
            command_insert_commande_bicyclette.CommandText = insertCommandebicyclette;

            try
            {
                command_insert_commande_bicyclette.ExecuteNonQuery();
                Console.WriteLine("Bicyclette lié à la commande crée !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_insert_commande_bicyclette.Dispose();
            #endregion

        }
        #endregion


        #region Supression de Pièces, Clients, Fournisseurs et commandes 


        static void SuppPiece()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Suppression Commande

            MySqlParameter no_piece = new MySqlParameter("@no_piece", MySqlDbType.VarChar);
            Console.Write("Saisir le numéro de la commande à supprimer (e.g C32) : ");
            no_piece.Value = Console.ReadLine();

            string suppPiece = "DELETE from piece where piece.no_piece=@no_piece;";

            MySqlCommand command_supp_piece = maConnexion.CreateCommand();
            command_supp_piece.CommandText = suppPiece;
            command_supp_piece.Parameters.Add(no_piece);

            try
            {
                command_supp_piece.ExecuteNonQuery();
                Console.WriteLine("Piece supprimé !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;

            }
            command_supp_piece.Dispose();

            #endregion
        }

        static void SuppClientsInd()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Suppression Client Individuel


            int no_client;
            Console.Write("Saisir le numéro du client à supprimer (e.g 1) : ");
            no_client = Convert.ToInt32(Console.ReadLine());

            string suppClient = "DELETE from client_individuel where client_individuel.no_client=" + no_client + ";";

            MySqlCommand command_supp_client = maConnexion.CreateCommand();
            command_supp_client.CommandText = suppClient;

            try
            {
                command_supp_client.ExecuteNonQuery();
                Console.WriteLine("Client supprimé !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;

            }
            command_supp_client.Dispose();

            #endregion

        }

        static void SuppClientsBout()
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Suppression Client Boutique

            MySqlParameter nom_compagnie = new MySqlParameter("@nom_compagnie", MySqlDbType.VarChar);
            Console.Write("Saisir le nom de L'entreprise cliente à supprimer (e.g Veloworld) : ");
            nom_compagnie.Value = Console.ReadLine();

            string suppClient_Entreprise = "DELETE from client_boutique where client_boutique.nom_compagnie=@nom_compagnie;";

            MySqlCommand command_supp_client_Entreprise = maConnexion.CreateCommand();
            command_supp_client_Entreprise.CommandText = suppClient_Entreprise;
            command_supp_client_Entreprise.Parameters.Add(nom_compagnie);

            try
            {
                command_supp_client_Entreprise.ExecuteNonQuery();
                Console.WriteLine("Client Boutique supprimé !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;

            }
            command_supp_client_Entreprise.Dispose();

            #endregion

        }

        static void SuppFournisseurs()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Suppression Fournisseur

            MySqlParameter nom_entreprise = new MySqlParameter("@nom_entreprise", MySqlDbType.VarChar);
            Console.Write("Saisir le nom de L'entreprise cliente à supprimer (e.g Stuff) : ");
            nom_entreprise.Value = Console.ReadLine();

            string suppFournisseur = "DELETE from fournisseur where fournisseur.nom_entreprise=@nom_entreprise;";

            MySqlCommand command_supp_fournisseur = maConnexion.CreateCommand();
            command_supp_fournisseur.CommandText = suppFournisseur;
            command_supp_fournisseur.Parameters.Add(nom_entreprise);

            try
            {
                command_supp_fournisseur.ExecuteNonQuery();
                Console.WriteLine("Fournisseur supprimé !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;

            }
            command_supp_fournisseur.Dispose();

            #endregion


        }

        static void SuppCommandes()
        {


            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Suppression Commande
            //MySqlParameter no_commande = new MySqlParameter("@no_commande", MySqlDbType.VarChar);
            string no_commande;
            Console.Write("Saisir le numéro de la commande à supprimer (e.g 1) : ");
            no_commande = Console.ReadLine();

            #region  On augment les quantites dans le stock de pieces 

            string piecesdecommande = "Select no_piece from contient_piece where no_commande='" + no_commande + "';";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = piecesdecommande;
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string no_piece = "";

            while (reader.Read())
            {
                no_piece = reader.GetString(0);
                Commande_modif_stock_piece(2, no_commande.ToString(), no_piece);
            }
            reader.Close();
            #endregion

            #region  On augment les quantites dans le stock de pieces liés au velo 
            string velodecommande = "Select no_bicyclette from contient_bicyclette where no_commande='" + no_commande + "';";
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = velodecommande;
            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();
            string no_bicyclette = "";

            while (reader2.Read())
            {
                no_bicyclette = reader2.GetString(0);
                Commande_modif_stock_piece_du_velo(2, no_commande.ToString(), no_bicyclette);
            }
            reader2.Close();
            #endregion

            string suppCommande = "DELETE from commande where no_commande='" + no_commande + "';";

            MySqlCommand command_supp_commande = maConnexion.CreateCommand();
            command_supp_commande.CommandText = suppCommande;
            //command_supp_commande.Parameters.Add(no_commande);

            try
            {
                //Une fois les quantites modifies dans le sotck on peut supprimer la commande
                command_supp_commande.ExecuteNonQuery();
                Console.WriteLine("Commande supprimée !");

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }

            command_supp_commande.Dispose();

            #endregion


        }



        #endregion


        #region Commande et suppression modifie le stock
        //Met à jour automatiquement le stock lorsqu'une commande est passée ou qu'elle est supprimée
        static void Commande_modif_stock_piece(int action, string no_commande, string no_piece)
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region selectionne la quantite de piece dans la commande
            string cherche_quantite_commande = "Select quantite_piece from contient_piece where no_commande='" + no_commande + "' and no_piece='" + no_piece + "';";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = cherche_quantite_commande;
            int quantite_piece_commande = 0;

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())   // parcours ligne par ligne
            {
                quantite_piece_commande = reader.GetInt32(0);
            }
            reader.Close();
            #endregion

            //créer une commande il faut que le sotck correspondant diminue
            #region
            string cherche_quantite_stock = "Select quantite_stock from piece where no_piece='" + no_piece + "';";

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = cherche_quantite_stock;
            int quantite_piece_stock = 0;

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();

            while (reader2.Read())   // parcours ligne par ligne
            {
                quantite_piece_stock = reader2.GetInt32(0);
            }
            reader2.Close();



            if (action == 1) //si on crée une commande
            {
                if (quantite_piece_stock >= quantite_piece_commande && no_piece != "null" && StockPieces(no_commande, no_piece))//si la piece est bien en stock 
                {

                    if (quantite_piece_stock == 0)
                    {
                        Console.WriteLine("Attention la piece " + no_piece + " n'est plus en stock");
                        Console.WriteLine("Erreur, stock insuffisant");
                    }
                    else
                    {
                        quantite_piece_stock = quantite_piece_stock - quantite_piece_commande;
                    }
                }

            }


            if (action == 2)  //si on supprime une commande
            {

                quantite_piece_stock = quantite_piece_stock + quantite_piece_commande;


            }

            string update_Client = "Update piece set quantite_stock ='" + quantite_piece_stock + "' where no_piece='" + no_piece + "';";

            MySqlCommand command_update_piece = maConnexion.CreateCommand();
            command_update_piece.CommandText = update_Client;

            try
            {
                command_update_piece.ExecuteNonQuery();
                Console.WriteLine("Stock mis à jour !");
                Console.WriteLine();
                //MAJPieces();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_update_piece.Dispose();




            #endregion
        }


        static void Commande_modif_stock_piece_du_velo(int action, string no_commande, string no_bicyclette)
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region verifier stock d'une bicyclette pour une commande

            string cherche_quantite_commande = "Select quantite_bicyclette from contient_bicyclette where no_commande='" + no_commande + "' and no_bicyclette='" + no_bicyclette + "';";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = cherche_quantite_commande;
            int quantite_velo_commande = 0;

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())   // parcours ligne par ligne
            {
                quantite_velo_commande = reader.GetInt32(0);
            }
            reader.Close();

            //On obtient la quantite de velo demande dans la commande 

            //on cherche la quantite de piece en stock correspondant

            string cherche_pieces_velo = "Select * from assemblage join bicyclette on assemblage.nom_bicyclette = bicyclette.nom_bicyclette where no_bicyclette = '" + no_bicyclette + "';";
            MySqlCommand pieceDuVelo = maConnexion.CreateCommand();
            pieceDuVelo.CommandText = cherche_pieces_velo;
            MySqlDataReader reader2;
            string no_piece;

            reader2 = pieceDuVelo.ExecuteReader();
            while (reader2.Read())   // parcours ligne par ligne
            {
                for (int i = 3; i < reader2.FieldCount - 5; i++)
                {
                    if (!reader2.IsDBNull(i))
                    {
                        no_piece = reader2.GetString(i);
                    }
                    else
                    {
                        no_piece = "null";
                    }
                    if (action == 1)
                    {
                        Commande_modif_stock_piece(1, no_commande, no_piece);
                    }
                    if (action == 2)
                    {
                        Commande_modif_stock_piece(2, no_commande, no_piece);
                    }

                }



                #endregion
            }
            reader2.Close();

        }
        #endregion


        #region Mise à jour de Pièces, Clients, Fournisseurs et commandes  


        static void MAJPieces()
        {
            AffichePieces();
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Mise a jour pièces
            // Attributs de la Table client_individuel
            string no_piece;
            string new_value;
            string to_change;


            Console.Write("Quel Piece souhaitez-vous modifier ?(e.g C32) : ");
            no_piece = Console.ReadLine();

            Console.Write("Que souhaitez_vous modifier ? (description pour description_piece,catalogue pour no_catalogue_fournisseur, ect): ");
            Console.Write("Attention pour la date, respectez le format YYYY-MM-DD ");
            to_change = Console.ReadLine();

            Console.Write("Quelle valeur souhaitez-vous lui donner ? : ");
            new_value = Console.ReadLine();

            string update_Client = "Update piece set no_piece ='" + new_value + "' where no_piece=" + no_piece + ";";

            //if (to_change == "no")
            //{
            //    update_Client = "Update piece set no_piece ='" + new_value + "' where no_piece='" + no_piece + "';";
            //}
            if (to_change == "description")
            {
                update_Client = "Update piece set description_piece ='" + new_value + "' where no_piece='" + no_piece + "';";
            }
            if (to_change == "nom")
            {
                update_Client = "Update piece set nom_fournisseur ='" + new_value + "' where no_piece='" + no_piece + "';";
            }
            if (to_change == "catalogue")
            {
                update_Client = "Update piece set no_catalogue_fournisseur ='" + new_value + "' where no_piece='" + no_piece + "';";
            }
            if (to_change == "dateI")
            {
                update_Client = "Update piece set date_intro_piece =CAST('" + new_value + "' AS DATETIME) where no_piece='" + no_piece + "';";
            }
            if (to_change == "dateD")
            {
                update_Client = "Update piece set date_discontinuation_piece =CAST('" + new_value + "' AS DATETIME) where no_piece='" + no_piece + "';";
            }
            if (to_change == "quantite")
            {
                update_Client = "Update piece set quantite_stock ='" + Convert.ToInt32(new_value) + "' where no_piece='" + no_piece + "';";
            }



            MySqlCommand command_update_piece = maConnexion.CreateCommand();
            command_update_piece.CommandText = update_Client;

            try
            {
                command_update_piece.ExecuteNonQuery();
                Console.WriteLine("Piece mise à jour !");
                Console.WriteLine();
                MAJPieces();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_update_piece.Dispose();

            #endregion
        }

        static void MAJClientInd()
        {

            AfficheClientsInd();
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Mise a jour client ind
            // Attributs de la Table client_individuel
            int no_client;
            string new_value;
            string to_change;


            Console.Write("Quel client souhaitez-vous modifier ?(e.g 1) : ");
            no_client = Convert.ToInt32(Console.ReadLine());

            Console.Write("Que souhaitez_vous modifier ? (nom pour nom_client,prenom pour prenom_client, ect): ");
            to_change = Console.ReadLine();

            Console.Write("Quelle valeur souhaitez-vous lui donner ? : ");
            new_value = Console.ReadLine();

            string update_Client = "Update client_individuel set nom_client =" + new_value + " where no_client=" + no_client + ";";

            //switch (to_change)
            //{
            //    case "nom":

            //        break;
            //    case "nom":

            //        break;
            //}

            if (to_change == "nom")
            {
                update_Client = "Update client_individuel set nom_client = '" + new_value + "' where no_client=" + no_client + ";";
            }
            if (to_change == "prenom")
            {
                update_Client = "Update client_individuel set prenom_client = '" + new_value + "' where no_client=" + no_client + ";";
            }
            if (to_change == "adresse")
            {
                update_Client = "Update client_individuel set adresse_client ='" + new_value + "' where no_client=" + no_client + ";";
            }
            if (to_change == "tel")
            {
                update_Client = "Update client_individuel set tel_client ='" + new_value + "' where no_client=" + no_client + ";";
            }
            if (to_change == "courriel")
            {
                update_Client = "Update client_individuel set courriel_client ='" + new_value + "' where no_client=" + no_client + ";";
            }



            MySqlCommand command_update_client = maConnexion.CreateCommand();
            command_update_client.CommandText = update_Client;

            try
            {
                command_update_client.ExecuteNonQuery();
                Console.WriteLine("Client mis à jour !");
                Console.WriteLine();
                MAJClientInd();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_update_client.Dispose();

            #endregion

        }

        static void MAJClientBout()
        {

            AffichageClientsBout();

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Mise à jour client Boutique
            // Attributs de la Table client_boutique
            string nom_compagnie;
            string new_value;
            string to_change;


            Console.Write("Quel client Boutique souhaitez-vous modifier ?(e.g 1) : ");
            nom_compagnie = Console.ReadLine();

            Console.Write("Que souhaitez_vous modifier ? (nom pour nom_compagnie, contact pour nom_contact_boutique, remise pour pourcentage_remise): ");
            to_change = Console.ReadLine();

            Console.Write("Quelle valeur souhaitez-vous lui donner ? : ");
            new_value = Console.ReadLine();

            string update_ClientB = "Update client_boutique set nom_compagnie='" + new_value + "' where nom_compagnie='" + nom_compagnie + "';";

            if (to_change == "nom")
            {
                update_ClientB = "Update client_boutique set nom_compagnie='" + new_value + "' where nom_compagnie='" + nom_compagnie + "';";
            }
            if (to_change == "adresse")
            {
                update_ClientB = "Update client_boutique set adresse_boutique='" + new_value + "' where nom_compagnie='" + nom_compagnie + "';";
            }
            if (to_change == "tel")
            {
                update_ClientB = "Update client_boutique set tel_boutique='" + new_value + "' where nom_compagnie='" + nom_compagnie + "';";
            }
            if (to_change == "courriel")
            {
                update_ClientB = "Update client_boutique set courriel_boutique='" + new_value + "' where nom_compagnie='" + nom_compagnie + "';";
            }
            if (to_change == "contact")
            {
                update_ClientB = "Update client_boutique set nom_contact_boutique='" + new_value + "' where nom_compagnie='" + nom_compagnie + "';";
            }
            if (to_change == "remise")
            {
                update_ClientB = "Update client_boutique set pourcentage_remise='" + float.Parse(new_value) + "' where nom_compagnie='" + nom_compagnie + "';";
            }



            MySqlCommand command_update_clientB = maConnexion.CreateCommand();
            command_update_clientB.CommandText = update_ClientB;

            try
            {
                command_update_clientB.ExecuteNonQuery();
                Console.WriteLine("Client mis à jour !");
                Console.WriteLine();
                MAJClientBout();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_update_clientB.Dispose();

            #endregion
        }

        static void MAJFournisseurs()
        {

            AffichageFournisseurs();

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Mise à jour Fournisseur
            // Attributs de la Table fournisseurs
            string nom_entreprise;
            string new_value;
            string to_change;


            Console.Write("Quel Fournisseur souhaitez-vous modifier ?(e.g Stuff) : ");
            nom_entreprise = Console.ReadLine();

            Console.Write("Que souhaitez_vous modifier ? (e.g nom pour nom_entreprise, libelle pour libelle_satisfaction): ");
            to_change = Console.ReadLine();

            Console.Write("Quelle valeur souhaitez-vous lui donner ? : ");
            new_value = Console.ReadLine();

            string update_Fournisseur = "Update fournisseur set nom_entreprise='" + new_value + "' where nom_entreprise='" + nom_entreprise + "';";

            if (to_change == "siret")
            {
                update_Fournisseur = "Update fournisseur set siret='" + new_value + "' where nom_entreprise='" + nom_entreprise + "';";
            }
            if (to_change == "nom")
            {
                update_Fournisseur = "Update fournisseur set nom_entreprise='" + new_value + "' where nom_entreprise='" + nom_entreprise + "';";
            }
            if (to_change == "contact")
            {
                update_Fournisseur = "Update fournisseur set contact_entreprise='" + new_value + "' where nom_entreprise='" + nom_entreprise + "';";
            }
            if (to_change == "adresse")
            {
                update_Fournisseur = "Update fournisseur set adresse_entreprise='" + new_value + "' where nom_entreprise='" + nom_entreprise + "';";
            }
            if (to_change == "libelle")
            {
                update_Fournisseur = "Update fournisseur set libelle_satisfaction='" + Convert.ToInt32(new_value) + "' where nom_entreprise='" + nom_entreprise + "';";
            }


            MySqlCommand command_update_fournisseur = maConnexion.CreateCommand();
            command_update_fournisseur.CommandText = update_Fournisseur;

            try
            {
                command_update_fournisseur.ExecuteNonQuery();
                Console.WriteLine("Frounisseur mis à jour !");
                Console.WriteLine();
                MAJFournisseurs();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_update_fournisseur.Dispose();

            #endregion
        }



        static void MAJCommandes_General()
        {
            string no_commande;
            int selection;
            Console.WriteLine("Voici les commandes en cours :");
            AffichageCommandes();
            Console.WriteLine("Quelle commande souhaitez-vous modifier ?");
            no_commande = Console.ReadLine();

            Console.WriteLine("Que souhaitez-vous modifier : ");
            Console.WriteLine("1-Les donnnées des commandes ici affichés");
            Console.WriteLine("2-Les noms ou quantites de vélos commandés");
            Console.WriteLine("3-Les noms ou quantites de pièces commandés");
            selection = Convert.ToInt32(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    MAJCommandes();
                    break;

                case 2:
                    AffichageContientBic(no_commande);
                    MAJContient_Bicyclette(no_commande);
                    break;

                case 3:
                    AffichageContientPiece(no_commande);
                    MAJContient_Piece(no_commande);
                    break;


            }


        }

        static void MAJCommandes()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Mise à jour des instances de la commandes

            // Attributs de la Table commande
            string no_commande;
            string new_value;
            string to_change;


            Console.Write("Quel Commande souhaitez-vous modifier ?(e.g 1) : ");
            no_commande = Console.ReadLine();

            Console.Write("Que souhaitez_vous modifier ? (e.g dateC pour date_commande, dateL pour date_livraison, client pour no_client, compagnie pour no_compagnie): ");
            Console.Write("Attention pour la date, respectez le format YYYY-MM-DD ");
            to_change = Console.ReadLine();

            Console.Write("Quelle valeur souhaitez-vous lui donner ? : ");
            new_value = Console.ReadLine();

            string update_Commande = "Update commande set date_commande='" + new_value + "' where no_commande='" + no_commande + "';";

            if (to_change == "commande")
            {
                update_Commande = "Update commande set no_commande='" + new_value + "' where no_commande='" + no_commande + "';";
            }
            if (to_change == "dateC")
            {
                update_Commande = "Update commande set date_commande=CAST('" + new_value + "' AS DATETIME) where no_commande='" + no_commande + "';";
            }
            if (to_change == "adresse")
            {
                update_Commande = "Update commande set adresse_livraison='" + new_value + "' where no_commande='" + no_commande + "';";
            }
            if (to_change == "dateL")
            {
                update_Commande = "Update commande set date_livraison=CAST('" + new_value + "' AS DATETIME) where no_commande='" + no_commande + "';";
            }
            if (to_change == "compagnie")
            {
                update_Commande = "Update commande set nom_compagnie='" + new_value + "' where no_commande='" + no_commande + "';";
            }
            if (to_change == "client")
            {
                update_Commande = "Update commande set no_client='" + Convert.ToInt32(new_value) + "' where no_commande='" + no_commande + "';";
            }


            MySqlCommand command_update_commande = maConnexion.CreateCommand();
            command_update_commande.CommandText = update_Commande;

            try
            {
                command_update_commande.ExecuteNonQuery();
                Console.WriteLine("Commande mise à jour !");
                Console.WriteLine();
                MAJCommandes();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                return;
            }
            command_update_commande.Dispose();

            #endregion


        }

        static void MAJContient_Piece(string no_commande)
        {


            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion

            #region Mise à jour de piece
            int selection;
            string new_value;
            string old_value;
            Console.WriteLine("Que souhaitez-vous modifier dans votre commande de pièces ?");
            Console.WriteLine("1- le type de pièce");
            Console.WriteLine("2- le nombre de pièce");
            selection = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insérer le numero de la piece dont vous souhaitez modifier les parametres");
            old_value = Console.ReadLine();
            Console.WriteLine("Insérer la nouvelle valeur");
            new_value = Console.ReadLine();

            string update_Commande = "Update contient_piece set no_piece ='" + new_value + "' where no_commande = '" + no_commande + "' and no_piece = '" + old_value + "';";

            switch (selection)
            {
                case 1:
                    update_Commande = "Update contient_piece set no_piece ='" + new_value + "' where no_commande = '" + no_commande + "' and no_piece = '" + old_value + "';";
                    break;
                case 2:
                    update_Commande = "Update contient_piece set quantite_piece ='" + Convert.ToInt32(new_value) + "' where no_commande = '" + no_commande + "' and no_piece = '" + old_value + "';";
                    if (Convert.ToInt32(new_value) == 0)
                    {
                        Console.WriteLine("Attention la piece" + old_value + "n'est plus en stock!");
                    }
                    break;


            }

            MySqlCommand command_update_contient_piece = maConnexion.CreateCommand();
            command_update_contient_piece.CommandText = update_Commande;

            try
            {
                command_update_contient_piece.ExecuteNonQuery();
                Console.WriteLine("Piece mise à jour !");
                Console.WriteLine();
                MAJCommandes_General();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());
                Console.ReadLine();
                Console.WriteLine("Vous avez peut-être rentré une pièce qui n'existe pas ");
                Console.WriteLine("Essayez encore");
                MAJCommandes_General();
                return;
            }
            command_update_contient_piece.Dispose();
            #endregion

        }

        static void MAJContient_Bicyclette(string no_commande)
        {


            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region Mise à jour de piece
            int selection;
            string new_value;
            string old_value;
            Console.WriteLine("Que souhaitez-vous modifier dans votre commande de bicyclettes ?");
            Console.WriteLine("1- le type de bicyclette");
            Console.WriteLine("2- le nombre de bicyclettes");
            selection = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insérer le numero de la bicyclette dont vous souhaitez modifier les parametres (e.g 101)");
            old_value = Console.ReadLine();
            Console.WriteLine("Insérer la nouvelle valeur");
            new_value = Console.ReadLine();

            string update_Commande = "Update contient_bicyclette set no_bicyclette ='" + new_value + "' where no_commande = '" + no_commande + "' and no_bicyclette = '" + old_value + "';";

            switch (selection)
            {
                case 1:
                    update_Commande = "Update contient_bicyclette set no_bicyclette ='" + new_value + "' where no_commande = '" + no_commande + "' and no_bicyclette = '" + old_value + "';";
                    break;
                case 2:
                    update_Commande = "Update contient_bicyclette set quantite_bicyclette ='" + Convert.ToInt32(new_value) + "' where no_commande = '" + no_commande + "' and no_bicyclette = '" + old_value + "';";
                    break;


            }

            MySqlCommand command_update_contient_bicyclette = maConnexion.CreateCommand();
            command_update_contient_bicyclette.CommandText = update_Commande;

            try
            {
                command_update_contient_bicyclette.ExecuteNonQuery();
                Console.WriteLine("Piece mise à jour !");
                Console.WriteLine();
                MAJCommandes_General();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurInsert : " + e.ToString());

                Console.ReadLine();
                Console.WriteLine("Vous avez peut-être rentré une bicyclette qui n'existe pas ");
                Console.WriteLine("Essayez encore");
                MAJCommandes_General();



            }
            command_update_contient_bicyclette.Dispose();
            #endregion

        }

        #endregion


        #region Vérifier le stock

        static bool StockPieces(string no_commande, string no_piece) //Affiche si la pièce est en stock ou pas 
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());

            }
            #endregion

            #region verifier stock d'une piece pour une commande
            string cherche_quantite_commande = "Select quantite_piece from contient_piece where no_commande='" + no_commande + "' and no_piece='" + no_piece + "';";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = cherche_quantite_commande;
            int quantite_piece_commande = 0;

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())   // parcours ligne par ligne
            {
                quantite_piece_commande = reader.GetInt32(0);
            }
            reader.Close();
            //On obtient la quantite de piece demande dans la commande 

            //on cherche la quantite de piece en stock correspondant 
            //Select no_piece,quantite_stock from piece

            string cherche_quantite_stock = "Select quantite_stock from piece where no_piece='" + no_piece + "';";

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = cherche_quantite_stock;
            int quantite_piece_stock = 0;

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();

            while (reader2.Read())   // parcours ligne par ligne
            {
                quantite_piece_stock = reader2.GetInt32(0);
            }
            reader2.Close();

            if (quantite_piece_commande <= quantite_piece_stock)
            {
                Console.WriteLine("La piece " + no_piece + " est en stock");
                return true;
            }
            else
            {
                Console.WriteLine("La piece " + no_piece + "n'est pas en stock");
                Console.WriteLine("Passez commande");
                return false;

            }
            #endregion
        }

        static bool StockPieces_forBic(string no_piece, int quantite_ref)
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());

            }
            #endregion

            #region 
            //Select no_piece,quantite_stock from piece


            string cherche_quantite_stock = "Select quantite_stock from piece where no_piece='" + no_piece + "';";

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = cherche_quantite_stock;
            int quantite_piece_stock = 0;

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();

            while (reader2.Read())   // parcours ligne par ligne
            {
                quantite_piece_stock = reader2.GetInt32(0);
            }
            reader2.Close();

            if (quantite_ref <= quantite_piece_stock)
            {
                Console.WriteLine("La piece " + no_piece + " est en stock");
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("La piece " + no_piece + " n'est pas en stock");
                Console.WriteLine("Passez commande !");
                Console.WriteLine();
                return false;


            }
            #endregion
        }

        static void StockBicyclette(int no_commande, string no_bicyclette) //Affiche si les pièces du velo sont en stock ou pas 
        {

            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion


            #region verifier stock d'une bicyclette pour une commande

            string cherche_quantite_commande = "Select quantite_bicyclette from contient_bicyclette where no_commande='" + no_commande + "' and no_bicyclette='" + no_bicyclette + "';";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = cherche_quantite_commande;
            int quantite_velo_commande = 0;

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())   // parcours ligne par ligne
            {
                quantite_velo_commande = reader.GetInt32(0);
            }
            reader.Close();

            //On obtient la quantite de velo demande dans la commande 

            //on cherche la quantite de piece en stock correspondant
            string cherche_pieces_velo = "Select * from assemblage join bicyclette on assemblage.nom_bicyclette = bicyclette.nom_bicyclette where no_bicyclette = '" + no_bicyclette + "';";
            MySqlCommand pieceDuVelo = maConnexion.CreateCommand();
            pieceDuVelo.CommandText = cherche_pieces_velo;
            MySqlDataReader reader2;
            string no_piece;

            reader2 = pieceDuVelo.ExecuteReader();
            while (reader2.Read())   // parcours ligne par ligne
            {
                for (int i = 3; i < reader2.FieldCount - 5; i++)
                {
                    if (!reader2.IsDBNull(i))
                    {
                        no_piece = reader2.GetString(i);
                    }
                    else
                    {
                        no_piece = "null";
                    }

                    StockPieces_forBic(no_piece, quantite_velo_commande);
                }

            }
            reader2.Close();

            #endregion

        }

        #endregion


        #region Affichage Stock

        static void AfficherStockPiece() //affiche le stock de pièce et propose de passer commande si il manque des pièces en stock //Maybe Advise fournisseur ici
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());

            }
            #endregion

            #region Affiche la pièce et sa quantite en stock
            string cherche_quantite_stock = "Select no_piece,quantite_stock from piece;";

            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = cherche_quantite_stock;
            string no_piece;
            int quantite_piece_stock = 0;

            MySqlDataReader reader2;
            reader2 = command2.ExecuteReader();
            List<string> piece_abs = new List<string>();
            Console.WriteLine("Voici le stock de pièces");
            Console.WriteLine("numéro de la piece : quantite correspondante ");
            while (reader2.Read())   // parcours ligne par ligne
            {
                no_piece = reader2.GetString(0);
                quantite_piece_stock = reader2.GetInt32(1);
                if (quantite_piece_stock == 0)
                {
                    piece_abs.Add(no_piece);
                }

                Console.WriteLine(no_piece + ": " + quantite_piece_stock);

            }
            reader2.Close();
            Console.WriteLine();
            Console.WriteLine("Attention voici les pièces manquantes en stock");
            for (int i = 0; i < piece_abs.Count; i++)
            {
                Console.WriteLine(piece_abs[i]);
            }

            string answer;
            Console.WriteLine("Voulez-vous passer commande? (Y/N)");
            answer = Console.ReadLine();
            if (answer == "Y")
            {

                string fournit;
                int prix_fournisseur_piece;
                int delai_fournisseur;
                string siret;
                string nom_fournisseur;
                string selection_fournisseur;
                int selection_quantite;

                //insert dans la table 
                for (int i = 0; i < piece_abs.Count; i++)
                {
                    fournit = "select * from fournit where no_piece='" + piece_abs[i] + "';";
                    Console.WriteLine(piece_abs[i]);
                    MySqlCommand command3 = maConnexion.CreateCommand();
                    command3.CommandText = fournit;
                    MySqlDataReader reader3;
                    reader3 = command3.ExecuteReader();
                    while (reader3.Read())   // parcours ligne par ligne
                    {
                        siret = reader3.GetString(1);
                        prix_fournisseur_piece = reader3.GetInt32(2);
                        delai_fournisseur = reader3.GetInt32(3);

                        if (siret == "36252187900034")
                        {
                            nom_fournisseur = "Piking";   //piking
                            Console.WriteLine(nom_fournisseur + ":" + prix_fournisseur_piece + "," + delai_fournisseur);

                        }
                        if (siret == "34536187900034")
                        {
                            nom_fournisseur = "Stuff";//Stuff
                            Console.WriteLine(nom_fournisseur + ":" + prix_fournisseur_piece + "," + delai_fournisseur);
                        }
                        else
                        {
                            nom_fournisseur = "Bicloune";//Bicloune
                            Console.WriteLine(nom_fournisseur + ":" + prix_fournisseur_piece + "," + delai_fournisseur);
                        }

                    }
                    reader3.Close();


                    Console.WriteLine("Quel fournisseur choissisez-vous? (Piking,Stuff ou Bicloune)");
                    Console.WriteLine("Attention ne choisir que parmi ceux proposés");
                    selection_fournisseur = Console.ReadLine();
                    Console.WriteLine("Quelle quantité voulez-vous commander ?");
                    selection_quantite = Convert.ToInt32(Console.ReadLine());

                    string update_piece_quantity_fournisseur = "update piece set nom_fournisseur ='" + selection_fournisseur + "',quantite_stock=quantite_stock+" + selection_quantite + " where no_piece='" + piece_abs[i] + "';";
                    MySqlCommand command_update_piece_quantity_fournisseur = maConnexion.CreateCommand();
                    command_update_piece_quantity_fournisseur.CommandText = update_piece_quantity_fournisseur;

                    try
                    {
                        command_update_piece_quantity_fournisseur.ExecuteNonQuery();
                        Console.WriteLine("Commande de la pièce faite !");
                        Console.WriteLine();

                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine(" ErreurInsert : " + e.ToString());
                        Console.ReadLine();
                        return;
                    }

                    command_update_piece_quantity_fournisseur.Dispose();


                }



            }
            if (answer == "N")
            {
                string answer2;
                Console.WriteLine("Retour Menu ou Retour Stock ?(M/S)");
                answer2 = Console.ReadLine();
                if (answer2 == "M")
                {
                    MethodeG();
                }
                if (answer2 == "S")
                {
                    AfficherStock();
                }


            }

            #endregion
        }

        static void AfficherStockFournisseur()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());

            }
            #endregion

            #region Affichage stock par fournisseur
            //select nom_fournisseur,no_piece,quantite_stock from piece join fournisseur on fournisseur.nom_entreprise = piece.nom_fournisseur where nom_fournisseur = "Stuff";
            List<String> nom_fournisseurs = new List<String>();
            string answer;
            Console.WriteLine("Voici la liste des fournisseurs :");
            AffichageFournisseurs();
            Console.WriteLine("Souhaitez vous accéder à tous les fournisseurs(tous) ou à un des fournisseurs suivants(e.g Bicloune)?");
            answer = Console.ReadLine();
            string affichage_fournisseur_stock;
            if (answer == "tous")
            {
                affichage_fournisseur_stock = "select nom_fournisseur,no_piece,quantite_stock from piece join fournisseur on fournisseur.nom_entreprise = piece.nom_fournisseur";
            }
            else
            {
                affichage_fournisseur_stock = "select nom_fournisseur,no_piece,quantite_stock from piece join fournisseur on fournisseur.nom_entreprise = piece.nom_fournisseur where nom_fournisseur ='" + answer + "';";
            }
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = affichage_fournisseur_stock;
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string nom_fournisseur = "";
            string no_piece;
            string quantite_stock;

            Console.WriteLine("nom fournisseur,numero de la pièce piece,quantite en stock de la piece ");
            while (reader.Read())   // parcours ligne par ligne
            {
                nom_fournisseur = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                no_piece = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                quantite_stock = reader.GetString(2);

                Console.WriteLine(nom_fournisseur + " : " + no_piece + " , " + quantite_stock);

            }
            reader.Close();
            Console.ReadKey();

            #endregion
        }

        static void AfficherStockVelo()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());

            }
            #endregion

            #region Affisher stock velo

            List<string> piece = new List<string>();
            string table_assemblage = "Select * from assemblage";
            List<string> velos = new List<string>();
            List<string> type = new List<string>();
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = table_assemblage;
            MySqlDataReader reader;
            reader = command.ExecuteReader();


            string no_piece;
            string quantite_stock;

            string requete_stock_piece;

            //Console.WriteLine("nom fournisseur,numero de la pièce piece,quantite en stock de la piece ");
            while (reader.Read())   // parcours ligne par ligne donc premier model de vélo ici 
            {
                velos.Add(reader.GetString(1));
                type.Add(reader.GetString(2));
                for (int i = 3; i < 15; i++)
                {
                    //piece.Add(reader.GetString(i)); // liste des pièces 
                    if (!reader.IsDBNull(i))
                    {
                        no_piece = reader.GetString(i);
                    }
                    else
                    {
                        no_piece = "null";
                    }
                    piece.Add(no_piece);

                }
            }
            reader.Close();
            List<string> piece_stock_insuffisant = new List<string>();
            List<int> quantite_piece_stock_insuffisant = new List<int>();
            Console.WriteLine("Voici les bicyclette ainsi que leurs pièces et le stock de chacune associé");
            Console.WriteLine();
            for (int counter = 11; counter < piece.Count - 11; counter = counter + 11)
            {

                Console.WriteLine(velos[(counter / 11) - 1] + "," + type[(counter / 11) - 1]);
                for (int i = counter - 11; i < counter; i++)
                {
                    requete_stock_piece = "Select no_piece,quantite_stock from piece where no_piece='" + piece[i] + "';";

                    MySqlCommand command2 = maConnexion.CreateCommand();
                    command2.CommandText = requete_stock_piece;
                    MySqlDataReader reader2;
                    reader2 = command2.ExecuteReader();

                    while (reader2.Read())
                    {
                        quantite_stock = reader2.GetString(1);
                        Console.Write(piece[i] + "," + quantite_stock + " | ");
                        if (Convert.ToInt32(quantite_stock) == 0)
                        {
                            piece_stock_insuffisant.Add(piece[i]);
                            quantite_piece_stock_insuffisant.Add(Convert.ToInt32(quantite_stock));
                        }
                    }
                    reader2.Close();

                }
                Console.WriteLine();
                Console.WriteLine();

            }
            Console.WriteLine("Attention votre stock est insufisant: ");

            for (int i = 0; i < piece_stock_insuffisant.Count; i++)
            {
                Console.WriteLine(piece_stock_insuffisant[i] + "," + quantite_piece_stock_insuffisant[i]);

            }

            #endregion

        }

        static void AfficherStockVelo_ParCatégorie()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());

            }
            #endregion

            #region Affiche stock velo par categorie
            string answer;
            string table_assemblage = "Select * from assemblage where grandeur_bicyclette ='Adultes';";
            Console.WriteLine("Quelle catégorie souhaitez-vous regarder ?");
            Console.WriteLine("Adultes (A), Hommes (H), Dames (D), Jeunes(J), Filles (F) ou Garçons (G)");
            answer = Console.ReadLine();

            switch (answer)
            {
                case "A":
                    table_assemblage = "Select * from assemblage where grandeur_bicyclette ='Adultes';";
                    break;
                case "H":
                    table_assemblage = "Select * from assemblage where grandeur_bicyclette ='Hommes';";
                    break;
                case "D":
                    table_assemblage = "Select * from assemblage where grandeur_bicyclette ='Dames';";
                    break;
                case "J":
                    table_assemblage = "Select * from assemblage where grandeur_bicyclette ='Jeunes';";
                    break;
                case "F":
                    table_assemblage = "Select * from assemblage where grandeur_bicyclette ='Filles';";
                    break;
                case "G":
                    table_assemblage = "Select * from assemblage where grandeur_bicyclette ='Garcons';";
                    break;

            }

            List<string> piece = new List<string>();
            List<string> velos = new List<string>();
            List<string> type = new List<string>();
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = table_assemblage;
            MySqlDataReader reader;
            reader = command.ExecuteReader();


            string no_piece;
            string quantite_stock;
            string requete_stock_piece;

            //Console.WriteLine("nom fournisseur,numero de la pièce piece,quantite en stock de la piece ");
            while (reader.Read())   // parcours ligne par ligne donc premier model de vélo ici 
            {
                velos.Add(reader.GetString(1));
                type.Add(reader.GetString(2));
                for (int i = 3; i < 15; i++)
                {
                    //piece.Add(reader.GetString(i)); // liste des pièces 
                    if (!reader.IsDBNull(i))
                    {
                        no_piece = reader.GetString(i);
                    }
                    else
                    {
                        no_piece = "null";
                    }
                    piece.Add(no_piece);

                }
            }

            reader.Close();
            int counter = 0;
            int indexer = 0;
            for (int i = 0; i < piece.Count; i++)
            {
                requete_stock_piece = "Select no_piece,quantite_stock from piece where no_piece='" + piece[i] + "';";

                MySqlCommand command2 = maConnexion.CreateCommand();
                command2.CommandText = requete_stock_piece;
                MySqlDataReader reader2;
                reader2 = command2.ExecuteReader();

                while (reader2.Read())
                {
                    quantite_stock = reader2.GetString(1);
                    Console.Write(piece[i] + "," + quantite_stock + " | ");

                }
                reader2.Close();
                counter++;
                if (counter == 12 || counter == 24 || counter == 36 || counter == 48)
                {
                    Console.WriteLine();
                    Console.WriteLine(velos[indexer] + "," + type[indexer]);
                    indexer++;
                }

            }



            #endregion

        }

        static void AfficherStock()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());

            }
            #endregion
            Console.WriteLine("Accéder au stock:");
            Console.WriteLine("1- Par Pièce");
            Console.WriteLine("2- Par Fournisseur");
            Console.WriteLine("3- Par Vélo");
            Console.WriteLine("4- Par Catégorie de vélo ( pour Adultes,enfants");
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    AfficherStockPiece();
                    break;
                case 2:
                    AfficherStockFournisseur();
                    break;
                case 3:
                    AfficherStockVelo();
                    break;
                case 4:
                    AfficherStockVelo_ParCatégorie();
                    break;

            }

        }
        #endregion












    }
}
