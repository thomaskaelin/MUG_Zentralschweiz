using System;
using System.ComponentModel;
using System.Threading;
using FluentAssertions;
using MUG_App.Event;
using MUG_App.Group;
using MUG_App.Organizer;
using MUG_App.Services;
using MUG_App.Test.Acceptance.Services;
using NUnit.Framework;

namespace MUG_App.Test.Acceptance
{
    [TestFixture]
    public class AcceptanceTests
    {
        [Test]
        public void AllViewModels_WithDummyLoader()
        {
            var loaderService = new DummyLoaderService();

            TestGroupViewModel(
                loaderService, 
                "Mobile User Group Zentralschweiz", 
                "Great mobile talks for everyone.", 
                string.Empty);

            TestOrganizerViewModel(
                loaderService,
                new Organizer.Organizer
                {
                    Name = "Loana Albisser",
                    Description = "Working for bbv since 2016.",
                    City = "Lucerne"
                },
                new Organizer.Organizer
                {
                    Name = "Thomas Kälin",
                    Description = "Working for bbv since 2013.",
                    City = "Lucerne"
                });

            TestEventViewModel(
                loaderService,
                new Event.Event
                {
                    Title = "Cool Topic",
                    Description = "Some super cool stuff here!",
                    RSVPCount = 5
                },
                new Event.Event
                {
                    Title = "Great Style",
                    Description = "It's going to be huuuuuuge.",
                    RSVPCount = 1337
                });
        }

        [Test]
        [Explicit]
        public void AllViewModels_WithRESTLoader()
        {
            var loaderService = new RESTLoaderService();

            TestGroupViewModel(
                loaderService,
                "Mobile User Group Zentralschweiz",
                "Bist du an Themen aus dem Bereich Mobile interessiert? Dann bist du bei der Mobile User Group Zentralschweiz genau richtig! Regelmässig werden hier interessante und derzeit aktuelle Themen vorgestellt. Beim anschliessendem Apéro kann man sich in gemütlicher Atmosphäre untereinander austauschen.",
                "https://secure.meetupstatic.com/photos/event/3/9/0/c/600_455954604.jpeg");

            TestOrganizerViewModel(
                loaderService,
                new Organizer.Organizer
                {
                    Name = "Loana Albisser",
                    Description = string.Empty,
                    City = "Luzern",
                    ImageUrl = "https://secure.meetupstatic.com/photos/member/a/9/d/0/member_263383472.jpeg"
                },
                new Organizer.Organizer
                {
                    Name = "Thomas Kälin",
                    Description = "Siehe Xing:\nhttps://www.xing.com/profile/Thomas_Kaelin12",
                    City = "Luzern",
                    ImageUrl = "https://secure.meetupstatic.com/photos/member/9/2/f/d/member_261697629.jpeg"
                });

            TestEventViewModel(
                loaderService,
                new Event.Event
                {
                    Title = "Mobile App Testing",
                    Description = "Abstract User haben hohe Erwartungen an die Qualität von Apps. Abstürze und Fehler führen schnell zu schlechten Bewertungen in den App Stores, was wiederum zu sinkenden Downloadzahlen führt. Viele solcher Fehler liessen sich durch frühzeitiges, automatisiertes Testen vor der Veröffentlichung finden und vermeiden. Doch Testing für Mobile Apps ist alles andere als einfach: die Vielzahl an Geräte- und Betriebssystemvarianten ist nur eine von vielen Herausforderungen. Im Rahmen des Vortrages werden die Herausforderungen beim Testing von Mobile Apps betrachtet. Darauf aufbauend werden mögliche Testarten und Testumgebungen aufgezeigt, mit welchen diese Herausforderungen adressiert werden können. Abgerundet wird die Präsentation durch ein Beispiel, welches die theoretischen Inhalte in der praktischen Anwendung aufzeigt. Agenda bis 18:00 Eintreffen &amp; Begrüssung 18:00-19:30  Hauptpräsentation ab 19:30  Apéro (Sponsoring bbv Software Services AG) Referenten Loana Albisser, Software Ingenieurin Mobile, bbv Software Services AG Thomas Kälin, Software Ingenieur Mobile, bbv Software Services AG ",
                    RSVPCount = 8
                },
                new Event.Event
                {
                    Title = "DevOps für Mobile Apps",
                    Description = "Abstract Mobile Dev Ops ist ein Traum vieler App-Entwicker: Nach einem Commit werden alle Unit-Tests ausgeführt, die UI Tests auf einer Device Cloud überprüft, die App für den Store verpackt und optimiert sowie automatisch in den Store übermittelt. Bei einem Absturz oder Fehler wird der Stacktrace automatisiert als neuer Bug erfasst, die Entwickler werden benachrichtigt und können den fehlerhaften Code korrigieren. Der Entwickler überarbeitet den Code, führt den Commit aus und der Prozess wiederholt sich von vorn. Thomas Charrière, Co-Community Lead Mobile bei bbv Software Services AG, zeigt auf, wie Dev Ops für Mobile Apps realisierbar ist und auf was man zu achten hat. Agenda bis 18:00 Eintreffen &amp; Begrüssung 18:00-19:30  Hauptpräsentation ab 19:30  Apéro (Sponsoring bbv Software Services AG) Referenten Thomas Charrière, Software Ingenieur Mobile, bbv Software Services AG ",
                    RSVPCount = 6
                },
                new Event.Event
                {
                    Title = "HoloLens 101: First experiences with holographic computing",
                    Description = "Abstract Microsoft HoloLens is a fascinating device, bringing augmented reality (or, to be precise, Mixed Reality) to a whole new level. Completely untethered, this Windows 10 computer is worn on your head, is fanless, has a battery life of a few hours, can run any Windows 10 Universal application, can be used to add virtual objects to the \"real reality\", and the range of possible applications defies the imagination. Everyone has to start somewhere! And this is where Laurent Bugnion, a 2D programming veteran with 20 years coding experience, but a 3D newbie, had to start too. Thankfully IdentityMine is an Official HoloLens partner since 2015, and gathered a lot of experience building applications for this exciting platform. In this session, we will understand what a HoloLens device is, how it works, see live demos, and then see how the 3D development environment is setup. We will use simple examples to understand how coding works in the 3D world and how you can interact with holograms :) This session will be rich in new information and in demos, so come prepared to experience a new reality. And who knows, you might be in the lucky few who get to try the device in 1:1 sessions later! Key learnings:  • Discover the HoloLens device and what makes it so unique • Build your first HoloLens application and understand how 3D programming works • See how Unity and Visual Studio with C# are leveraged to speed up development  Agenda bis 18:00 Eintreffen &amp; Begrüssung 18:00-19:30  Hauptpräsentation (in English)ab 19:30  Apéro (Sponsoring bbv Software Services AG) Über den Referenten Laurent Bugnion works as Senior Technical Evangelist for Valorem (previously IdentityMine), one of the leading companies (and Gold Partner) for Microsoft technologies such as Windows Presentation Foundation, Xamarin, Windows Store, Windows Phone, XBOX, Azure, Office 365 and more! He is based in Zurich Switzerland. Laurent writes for MSDN magazine and other publications, codes in Windows, WPF, Xamarin (iOS and Android), ASP.NET and his blog is on blog.galasoft.ch. He is a frequent speaker at conferences such as Microsoft MIX, TechEd, VSLive, TechDays and many other international events. He is a Microsoft Most Valuable Professional (Windows Application Development) since 2007, a Microsoft Regional Director since 2014 and a Xamarin Most Valuable Professional since 2015. He is the author of the well-known open source framework MVVM Light for Windows, WPF, Xamarin, and of the popular Pluralsight reference course about MVVM Light. ",
                    RSVPCount = 5
                });
        }

        #region Private Methods

        private static void TestGroupViewModel(
            IGroupLoaderService loaderService,
            string expectedName,
            string expectedDescription,
            string expectedImageUrl)
        {
            var groupViewModel = new GroupPageViewModel(loaderService);

            WaitForPropertyChanged(
                groupViewModel,
                () => groupViewModel.RefreshDataCommand.Execute(null),
                pce => pce.PropertyName == nameof(groupViewModel.Name));

            groupViewModel.Name.Should().Be(expectedName);
            groupViewModel.Description.Should().Be(expectedDescription);
            groupViewModel.ImageUrl.Should().Be(expectedImageUrl);
        }

        private static void TestOrganizerViewModel(
            IOrganizerLoaderService loaderService,
            params Organizer.Organizer[] expectedOrganizers)
        {
            var organizerViewModel = new OrganizerPageViewModel(loaderService);

            WaitForPropertyChanged(
                organizerViewModel,
                () => organizerViewModel.RefreshDataCommand.Execute(null),
                pce => pce.PropertyName == nameof(organizerViewModel.IsBusy) && !organizerViewModel.IsBusy);

            organizerViewModel.Organizers.Count.Should().Be(expectedOrganizers.Length);

            for (var i = 0; i < expectedOrganizers.Length; i++)
            {
                var expectedOrganizer = expectedOrganizers[i];
                var actualOrganizer = organizerViewModel.Organizers[i];

                actualOrganizer.Name.Should().Be(expectedOrganizer.Name);
                actualOrganizer.Description.Should().Be(expectedOrganizer.Description);
                actualOrganizer.City.Should().Be(expectedOrganizer.City);
                actualOrganizer.ImageUrl.Should().Be(expectedOrganizer.ImageUrl);
            }
        }

        private static void TestEventViewModel(
            IEventLoaderService loaderService,
            params Event.Event[] expectedEvents)
        {
            var eventViewModel = new EventPageViewModel(loaderService);

            WaitForPropertyChanged(
                eventViewModel,
                () => eventViewModel.RefreshDataCommand.Execute(null),
                pce => pce.PropertyName == nameof(eventViewModel.IsBusy) && !eventViewModel.IsBusy);

            eventViewModel.Events.Count.Should().Be(expectedEvents.Length);

            for (var i = 0; i < expectedEvents.Length; i++)
            {
                var expectedEvent = expectedEvents[i];
                var actualEvent = eventViewModel.Events[i];

                actualEvent.Title.Should().Be(expectedEvent.Title);
                actualEvent.Description.Should().Be(expectedEvent.Description);
                actualEvent.RSVPCount.Should().Be(expectedEvent.RSVPCount);
            }
        }

        private static void WaitForPropertyChanged(INotifyPropertyChanged source, Action asyncAction, Predicate<PropertyChangedEventArgs> condition)
        {
            var autoResetEvent = new AutoResetEvent(false);

            source.PropertyChanged += (sender, args) =>
            {
                if (condition(args))
                {
                    autoResetEvent.Set();
                }
            };

            asyncAction();

            var receivedSignal = autoResetEvent.WaitOne(TimeSpan.FromSeconds(5));
            receivedSignal.Should().BeTrue();
        }

        #endregion
    }
}
