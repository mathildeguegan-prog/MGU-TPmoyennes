using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
     class Eleve
    {
        public string prenom { get; set; }
        public string nom { get; set; }

        public List<Note> notes { get; set; } = new List<Note>();

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
        }
        
        // 200 notes max
        public void ajouterNote(Note note)
        {
            if (notes.Count <= 200)
            {
                notes.Add(note);
            }
        }

        // Moyenne pour une matière
        public float moyenneMatiere(int matiere)
        {
            float somme = 0;
            int compteur = 0;

            for (int i = 0; i<notes.Count; i++)
            {
                if (notes[i].matiere == matiere)
                {
                    somme = somme + notes[i].note;
                    compteur++;
                }
            }
            if (compteur == 0)
                return 0;
            float moyenne = somme / compteur;
            return Tronquer(moyenne);
        }
        
        // Moyenne general de l'eleve
        public float moyenneGeneral()
        {
            float somme = 0;
            int nbMatiere = 0;

            for (int m = 0; m<10; m++)
            {
                float moy = moyenneMatiere(m);
                if (moy > 0)
                {
                    somme = somme + moy;
                    nbMatiere++;
                }
            }
            if (nbMatiere == 0) 
                return 0;
            float moyenne = somme / nbMatiere;
            return Tronquer(moyenne);
        }
        private float Tronquer(float valeur)
        {
            return (float)(Math.Floor(valeur * 100) / 100);
        }


    }
}
