using OpenQA.Selenium;

namespace ByteBank.WebApp.Testes.PageObjects
{
    public class HomePO
    {
        private readonly IWebDriver driver;
        private readonly By linkHome;
        private readonly By linkContasCorrente;
        private readonly By linkClientes;
        private readonly By linkAgencias;

        public HomePO(IWebDriver _driver)
        {
            driver = _driver;
            linkHome = By.Id("home");
            linkContasCorrente = By.Id("contacorrente");
            linkClientes = By.Id("clientes");
            linkAgencias = By.Id("agencia");
        }
        public void Navegar(string url) => driver.Navigate().GoToUrl(url);

        public void LinkHomeClick() => driver.FindElement(linkHome).Click();

        public void LinkAgenciaClick() => driver.FindElement(linkAgencias).Click();

        public void LinkClientesClick() => driver.FindElement(linkClientes).Click();

        public void LinkContaCorrenteClick() => driver.FindElement(linkContasCorrente).Click();
    }
}
