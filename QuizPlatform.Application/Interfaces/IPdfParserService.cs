using QuizPlatform.Application.DTOs;

namespace QuizPlatform.Application.Interfaces;

public interface IPdfParserService
{
    Task<PdfParseResultDto> ParsePdfAsync(Stream pdfStream, string fileName);
}
