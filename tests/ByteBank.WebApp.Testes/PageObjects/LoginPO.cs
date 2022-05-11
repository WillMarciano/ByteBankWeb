using OpenQA.Selenium;

namespace ByteBank.WebApp.Testes.PageObjects
{
    public class LoginPO
    {
        private readonly IWebDriver driver;
        private readonly By campoEmail;
        private readonly By campoSenha;
        private readonly By btnLogar;

        public LoginPO(IWebDriver _driver)
        {
            driver = _driver;
            campoEmail = By.Id("Email");
            campoSenha = By.Id("Senha");
            btnLogar = By.Id("btn-logar");
        }

        public void Navegar(string url) => driver.Navigate().GoToUrl(url);

        public void PreencherCampos(string email, string senha)
        {
            driver.FindElement(campoEmail).SendKeys(email);
            driver.FindElement(campoSenha).SendKeys(senha);
        }
        public void Logar() => driver.FindElement(btnLogar).Click();
    }
}
