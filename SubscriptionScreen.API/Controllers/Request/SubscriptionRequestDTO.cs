namespace SubscriptionScreen.API.Controllers.Request
{
    public class SubscriptionRequestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SubscriptionType { get; set; } //Troque isso para um tipo enum para ficar mais claro para quem for utilizar quais s�o os tipos que vc deseja
        public DateTime CreationDate { get; set; }

        //Remover essa propriedade na hora de criar uma nova subscri��o afinal vc nao pode criar uma subscri��o ja deletada 
        //public bool IsDeleted { get; set; } = false;
    }
}