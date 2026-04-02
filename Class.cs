using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
     class Classe
    {
        public string nomClasse { get; set; }
        public List<Eleve> eleves;
        public List<String> matieres;

        public Classe(string nom)
        {
            nomClasse = nom;
            eleves = new List<Eleve>();
            matieres = new List<String>();
        }

        // Ajout eleve pour la moyenne general
        public void ajouterEleve(string prenom, string nom)
        {
            if (eleves.Count < 30)
            {
                eleves.Add(new Eleve(prenom, nom));
            }
        }

        // Ajout matière
        public void ajouterMatiere(string matiere)
        {
            if (matieres.Count < 10)
            {
                matieres.Add(matiere);

            }
        }

        // Moyenne par matiere
        public float moyenneMatiere(int matiere)
        {
            float somme = 0;
            int compteur = 0;

            for (int i = 0; i < eleves.Count; i++) 
            {
                float moy = eleves[i].moyenneMatiere(matiere);
                somme = somme + moy;
                compteur++;

            }
            if (compteur == 0)
                return 0;

            float moyenne = somme / compteur;
            return Tronquer(moyenne);
        }

        // Moyenne general
        public float moyenneGeneral()
        {
            float somme = 0;
            int compteur = 0;

            for (int m = 0; m < matieres.Count; m++)
            {
                float moy = moyenneMatiere(m);
              somme += moy;
              compteur++;
            }
            
            if (compteur == 0)
            return 0;

            float moyenne = somme / compteur;
            return Tronquer(moyenne);
        }
        private float Tronquer(float valeur)
        {
            return (float)(Math.Floor(valeur * 100) / 100);
        }
    }


}

// Moyenne de la class
// quelle classe
// 30 eleve max