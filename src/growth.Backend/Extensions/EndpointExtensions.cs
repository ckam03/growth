using growth.Backend.Features.Audio;
using growth.Backend.Features.Entry;
using growth.Backend.Features.Entry.Endpoints;
using growth.Backend.Features.Journals.Endpoints;
using growth.Backend.Features.Motivation;
using growth.Backend.Features.Unsplash;

namespace growth.Backend.Extensions;

public static class EndpointExtensions
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapGroup("/journal").WithTags("Journal")
                                .MapGetJournal()
                                .MapGetJournals()
                                .MapCreateJournal()
                                .MapDeleteJournal();
                                
        app.MapGroup("/entry").WithTags("JournalEntry")
                              .MapGetJournalEntry()
                              .MapGetJournalEntries()
                              .MapCreateJournalEntry()
                              .MapUpdateJournalEntry()
                              .MapDeleteJournalEntry();

        app.MapGroup("/audio").MapGetAudioFiles();
        app.MapGroup("/photos").MapGetPhotos().WithTags("Photos");
        app.MapGroup("/quote").MapGetQuote();

        app.MapGroup("/image").WithTags("Image")
                              .MapGetPhoto()
                              .MapSelectPhoto();
        return app;
    }
}
