using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void RealizarPesquisas(List<string> termos, int repeticoes, string perfilPath)
    {
        // Configuração do Edge WebDriver com o perfil do usuário
        var options = new EdgeOptions();
        options.AddArgument($"user-data-dir={perfilPath}");  // Caminho para o perfil do usuário
        options.AddArgument("--start-maximized");  // Maximizar janela

        using (var driver = new EdgeDriver(options))
        {
            try
            {
                for (int i = 0; i < repeticoes; i++)
                {
                    Console.WriteLine($"Execução {i + 1} de {repeticoes}:");

                    foreach (var termo in termos)
                    {
                        Console.WriteLine($"Pesquisando por: {termo}");

                        // Abre a página inicial do Bing
                        driver.Navigate().GoToUrl("https://www.bing.com");

                        // Encontra a barra de pesquisa, limpa o campo, digita o termo e seleciona a tecla Enter para pesquisar
                        var barraPesquisa = driver.FindElement(By.Name("q"));
                        barraPesquisa.Clear();
                        barraPesquisa.SendKeys(termo);
                        barraPesquisa.SendKeys(Keys.Enter);

                        // Aguardar alguns segundos para contabilizar os pontos
                        Thread.Sleep(5000);
                    }
                }
            }
            finally
            {
                // Fecha o navegador
                driver.Quit();
            }
        }
    }

    static void Main(string[] args)
    {
        // Lista com os termos para pesquisa
        List<string> termosParaPesquisa = new List<string>
        {
            // Fundamentos
            "sintaxe python", "tipos de dados python", "estruturas de controle python", "funções python", "módulos python",
            "pacotes python", "orientação a objetos python", "herança python", "polimorfismo python", "exceções python",

            // Estruturas de Dados
            "listas python", "tuplas python", "dicionários python", "conjuntos python", "pilhas python", "filas python",

            // Bibliotecas Essenciais
            "pandas python", "numpy python", "matplotlib python", "seaborn python", "scikit-learn python",

            // Ciência de Dados e Machine Learning
            "regressão linear python", "árvore de decisão python", "random forest python", "clustering python", "neural networks python",
            "deep learning python", "tensorflow python", "pytorch python", "keras python", "nlp python",

            // Desenvolvimento Web
            "flask python", "django python", "rest api python", "web scraping python", "beautifulsoup python",

            // Outros Tópicos
            "testes unitários python", "depuração python", "versionamento de código python", "git python", "docker python",
            "programação concorrente python", "programação assíncrona python", "design patterns python", "algoritmos python", "estrutura de dados python"
        };

        // Define a quantidade de vezes que o loop de pesquisa será executado
        int quantidadeDePesquisas = 1;

        // Utiliza o perfil com a conta Microsoft logada para receber os pontos
        // Atualize este caminho para o correto para cada pessoa
        string caminhoPerfil = @"C:\Users\Lucas\AppData\Local\Microsoft\Edge\User Data\Default";

        // Execução da função
        RealizarPesquisas(termosParaPesquisa, quantidadeDePesquisas, caminhoPerfil);
    }
}