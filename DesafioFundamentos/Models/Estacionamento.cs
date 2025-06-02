namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }
        // <<<<< Adioninar Veículo  no Sistema >>>>>
           public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

        // <<<<< Verificar se o veículo já não foi adicionado >>>>>
            if (!veiculos.Any(x => string.Equals(x, placa, StringComparison.OrdinalIgnoreCase)))
            {
                veiculos.Add(placa);
                Console.WriteLine("O veículo foi adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("O veículo não foi adicionado. Não pode ter dois veículos com a mesma placa!");
            }
        }
        // <<<<<Remover Veículo  do Sistema >>>>>
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

        // <<<<< Verificar se o veículo existe >>>>>
            if (veiculos.Any(x => string.Equals(x, placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;

        // <<<<< Remover Veículo do Sistema ----- ignorando maiúsculas/minúsculas>>>>>
                    veiculos.Remove(veiculos.First(x => string.Equals(x, placa, StringComparison.OrdinalIgnoreCase)));

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Operação cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }
         //  <<<<< Lista de Veículos estacionados>>>>>
        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}