using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using szamkitjat;
using szamkitjatiterfaces;

namespace UnitTest
{
    [TestClass]
    public class GameTests
    {
        IHost testHost;
        public GameTests()
        {
            testHost = Host.CreateDefaultBuilder(null)
                            .ConfigureServices(services =>
                            {
                                var hang = new FakeHang();
                                var ui = new FakeUI();

                                services.AddSingleton<ISound, FakeHang>(x => hang);
                                services.AddSingleton<IGameUI, FakeUI>(x => ui);

                                services.AddSingleton<IGame, FakeGame>();

                                services.AddSingleton<IGameController, Game>(x => new Game(services.BuildServiceProvider()));

                            }).Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Constructor null paraméter exception test ok.")]
        public void GameContructorNullReferenceTest()
        {
            _ = new Game(null);
        }

        [TestMethod]
        public void GameCreateTest()
        {
            var game = new Game(testHost.Services);
            Assert.IsNotNull(game);
        }

        [TestMethod]
        public void KezdesMethodTest()
        {
            var gameCtrl = testHost.Services.GetRequiredService<IGameController>();
            var ui = (FakeUI)testHost.Services.GetRequiredService<IGameUI>();
            ui.ReadResult = 'X';

            gameCtrl.Kezdes();
            Assert.IsTrue(ui.TestSteps.Count > 4, "Nincs UI output vagy túl sok az output");
            Assert.IsTrue(ui.TestSteps[0].Contains("fg:DarkBlue|bg:Cyan"), "Törléskor nem megfelelő a szinek beállítása");
            Assert.IsTrue(ui.TestSteps[1].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[1].Contains("Music"), "Nem a Music zene kerül lejátszásra induláskor");
            Assert.IsTrue(ui.TestSteps[2].StartsWith("PrintLN"), "AZ UI nem printLN indít");
            Assert.IsTrue(ui.TestSteps[2].Contains("Üdv"), "Üdv hibás");
            Assert.IsTrue(ui.TestSteps[3].StartsWith("Sound"), "Nem a zene lejátszásával indul");
            Assert.IsTrue(ui.TestSteps[3].Contains("Music"), "Nem a Music zene kerül lejátszásra induláskor");
        }

        [TestMethod]
        public void EndingMethodTest()
        {
            var gameCtrl = testHost.Services.GetService<IGameController>();
            var ui = (FakeUI)testHost.Services.GetService<IGameUI>();

            gameCtrl.Ending();
            Assert.IsTrue(ui.TestSteps.Count == 1, "Nincs UI output vagy túl sok az output");
            Assert.IsTrue(ui.TestSteps[0].StartsWith("PrintLN"), "AZ UI nem printLN indít");
            Assert.IsTrue(ui.TestSteps[0].Contains("Viszlát"), "Visszlát hibás");
        }
    }
}