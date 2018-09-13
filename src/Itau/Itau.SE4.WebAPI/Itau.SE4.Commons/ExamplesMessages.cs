namespace Itau.SE4.Commons
{
    public class ExamplesMessages : IExamplesMessages
    {        
        public string GetIdadeNaoPermitida() => ("A idade preenchida não é permitida");
        public string GetIdadeAvancada() => ("A idade do participante é muito próxima a idade maxima permitida.");
        public string GetNameRequired(string field) => (string.Format("O campo: {0} do participante é obrigatório.",field));
        public string GetMaxLenght(string field, string value) => (string.Format("O campo : {0} tem o tamanho minimo de {1}",field,value));
    }
}
