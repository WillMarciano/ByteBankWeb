namespace ByteBank.Apresentacao.Menu
{
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine(MostrarCabecalho());
                Console.WriteLine(MostrarMenu());
                opcao = LerOpcaoMenu();
                ProcessarOpcaoMenu(opcao);
            } while (opcao != "4");
        }

        static string MostrarCabecalho()
        {
            return "[ CONTROLE DE CONTAS CORRENTES - BYTEBANK ]\n";
        }

        static string MostrarMenu()
        {
            string menu = "   Escolha uma opção:\n\n" +
                            "   1 - Cadastrar Agência\n" +
                            "   2 - Cadastrar Conta Corrente\n" +
                            "   3 - Listar Contas Correntes\n" +
                            "   4 - Sair do Programa \n";
            return menu;
        }

        static string LerOpcaoMenu()
        {
            string opcao;
            Console.Write("Opção desejada: ");
            opcao = Console.ReadLine();
            return opcao;
        }

        static void ProcessarOpcaoMenu(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    Acao.CadastarAgencia();
                    break;
                case "2":
                    Acao.CadastarConta();
                    break;
                case "3":
                    Acao.ListarContas();
                    break;
                case "4":
                    Console.WriteLine("Obrigado por utilizar o programa.");
                    break;
                default:
                    Console.WriteLine("Opção de menu inválida!");
                    break;
            }
        }
    }
}
