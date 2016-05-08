namespace GrosBrasInc.Models
{
    public interface IPourvoyeurDeLivraison
    {
        string nomPourvoyeur { get; }
        void GetTarifs();
    }
}
