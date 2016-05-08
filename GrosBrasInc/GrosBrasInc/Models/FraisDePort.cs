using System;

namespace GrosBrasInc.Models
{
    public class FraisDePort
    {
        public DateTime DateLivraison { get; set; }
        public string NomService { get; set; }
        public string NomPourvoyeur { get; set; } // Ex. poste canada, purolator
        public string CodeService { get; set; }
        public decimal Montant { get; set; }
        public FraisDePort(string p_nomPourvoyeur, string p_codeService, string p_nom, decimal p_montant, DateTime p_dateLivraison)
        {
            NomPourvoyeur = p_nomPourvoyeur;
            CodeService = p_codeService;
            NomService = p_nom;
            Montant = p_montant;
            DateLivraison = p_dateLivraison;
        }
    }
}
