using System;
using System.ComponentModel;
using System.Threading;
using FluentAssertions;
using MUG_App.Shared.Event;
using MUG_App.Shared.Group;
using MUG_App.Shared.Organizer;
using MUG_App.Shared.Services;
using MUG_App.Test.Integration.Services;
using Xunit;

namespace MUG_App.Test.Integration
{
    public class IntegrationTests
    {
        [Fact]
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
                new Organizer
                {
                    Name = "Loana Albisser",
                    Description = "Founder of the Mobile User Group.",
                    City = "Lucerne"
                },
                new Organizer
                {
                    Name = "Thomas Kälin",
                    Description = "Founder of the Mobile User Group.",
                    City = "Lucerne"
                });

            TestEventViewModel(
                loaderService,
                new Event
                {
                    Title = "Cool Topic",
                    Description = "Some super cool stuff here!",
                    RSVPCount = 5
                },
                new Event
                {
                    Title = "Great Style",
                    Description = "It's going to be huuuuuuge.",
                    RSVPCount = 1337
                });
        }

        [Fact(Skip = "Run only for validating communication with real backend.")]
        public void AllViewModels_WithRESTLoader()
        {
            var loaderService = new RESTLoaderService();

            TestGroupViewModel(
                loaderService,
                "Mobile User Group Zentralschweiz",
                "Bist du an Themen aus dem Bereich Mobile interessiert? Dann bist du bei der Mobile User Group Zentralschweiz genau richtig! Regelmässig werden hier interessante und derzeit aktuelle Themen vorgestellt. Beim anschliessendem Apéro kann man sich in gemütlicher Atmosphäre untereinander austauschen.",
                "https://secure.meetupstatic.com/photos/event/8/c/9/600_478622249.jpeg");

            TestOrganizerViewModel(
                loaderService,
                new Organizer
                {
                    Name = "Loana A.",
                    Description = string.Empty,
                    City = "Luzern",
                    ImageUrl = "https://secure.meetupstatic.com/photos/member/8/1/4/3/member_282993091.jpeg"
                },
                new Organizer
                {
                    Name = "Thomas K.",
                    Description = "Siehe Xing:\nhttps://www.xing.com/profile/Thomas_Kaelin12",
                    City = "Luzern",
                    ImageUrl = "https://secure.meetupstatic.com/photos/member/9/2/f/d/member_261697629.jpeg"
                });

            TestEventViewModel(
                loaderService,
                new Event
                {
                    Title = "Kotlin 💚 Android",
                    Description = "=== Abstract === Die immer noch relativ junge Sprache Kotlin bietet diverse interessante Möglichkeiten und Spracheigenschaften. In diesem Vortrag werden zuerst einige Sprach-Highlights wie Nullable-Typen, benannte Parameter &amp; Default-Werte und Extensions vorgestellt. Im zweiten Teil wird auf die spezifischer auf Stärken und Vorteile von Kotlin für Android eingegangen - wie die volle Interoperabilität mit Java und sehr praktische Erweiterungen aus den Kotlin-Android-Extensions. Das wird uns zur Schussfolgerung führen, dass Kotlin und Android gut harmonieren. Wie üblich können wir im anschliessenden Apéro über unsere Eindrücke und Erfahrungen fachsimpeln. Wir freuen uns auf einen informativen Austausch! === Agenda === bis 18:15 Eintreffen &amp; Begrüssung18:15-19:30 Hauptpräsentationab 19:30 Apéro === Referenten === Prof. Dr. Ruedi Arnold, Dozent für Informatik, HSLU Ruedi Arnold arbeitet seit 2012 als Informatik-Dozent an der Hochschule Luzern. Zu seinen Hauptinteressen gehören verschiedene Programmiersprachen und -Paradigmen und (mobile) Software-Entwicklung. Der zweifache Vater arbeitete davor dreieinhalb Jahre bei der Ergon Informatik AG in Zürich, nachdem er an der ETH Zürich Informatik bis zur Promotion studiert hat. Für Publikationen, Präsentationen, Lebenslauf usw. siehe: https://ruedi-arnold.com/ ",
                    RSVPCount = 5
                },
                new Event
                {
                    Title = "Dark Patterns – Die dunkle Seite des UX Designs",
                    Description = "=== Abstract === Dark Patterns sind Elemente auf einer Benutzeroberfläche, welche bewusst benutzerunfreundlich gestaltet sind. Durch gezielte psychologische Manipulation wird der Benutzer zu Handlungen verleitet, die eigentlich nicht in seinem Interesse liegen. Die oftmals subtile und kreative Irreführung dient den Zielen eines Unternehmens und nicht den Bedürfnissen und der Ethik des Benutzers. So werden zum Beispiel Kaufentscheidungen forciert oder das Einverständnis zur Weitergabe von persönlichen Daten eingefordert. Nicht nur kleinere Websites mit zweifelhaftem Ruf setzen Dark Patterns ein, sondern auch grosse Unternehmen, an denen die meisten Benutzer heute nicht mehr vorbei kommen. In diesem Talk werden…- Die Hauptkategorien von Dark Patterns beschrieben- Die Techniken erklärt, wie Benutzer in die Irre geführt werden- Viele Beispiele gezeigt- Auf den Verhaltenskodex im UX Design eingegangen === Agenda === bis 18:15 Eintreffen &amp; Begrüssung18:15-19:15 Hauptpräsentationab 19:15 Apéro === Referenten === Tobias Bregy, Senior UX Designer, bbv Software Services AG Tobias Bregy habe Arbeits- und Organisationspsychologie studiert und sich in den Bereichen Mobile UX und Prototyping vertieft. In Kundenprojekten erwarb er fundiertes Know-how in der Durchführung von Anforderungsanalysen, der Gestaltung von Interaktionskonzepten, der Erstellung von interaktiven Prototypen und der benutzerzentrierten Evaluation. Durch seine breite Erfahrung im User-Centered Design Process bringt er in allen Projektphasen die Benutzersicht ein. ",
                    RSVPCount = 9
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
            params Organizer[] expectedOrganizers)
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
            params Event[] expectedEvents)
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
