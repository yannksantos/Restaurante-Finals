namespace Application.Notificador
{
    public class Notificacao
    {
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
        protected string Mensagem { get; set; }

    }
}
