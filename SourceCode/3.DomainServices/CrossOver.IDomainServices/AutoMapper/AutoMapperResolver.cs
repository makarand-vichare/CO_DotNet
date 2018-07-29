using AutoMapper;
using CrossOver.EntityModels.SearchBook;
using CrossOver.InfraStructure.Logging;
using CrossOver.ViewModels;
using System;
using System.Globalization;
using System.Linq;

namespace CrossOver.IDomainServices.AutoMapper
{

    class ListCommaSeparatedStringResolver : IMemberValueResolver<BookEntityModel, BookViewModel, string[], string>
    {
        public string Resolve(BookEntityModel source, BookViewModel destination, string[] sourceMember, string destMember, ResolutionContext context)
        {
            return string.Join("','", sourceMember.Select(i => i).ToArray());
        }

    }

    public class DateResolver : IValueResolver<string, DateTime?, DateTime?>
    {
        public DateTime? Resolve(string source, DateTime? destination, DateTime? destMember, ResolutionContext context)
        {
            try
            {
                return DateTime.ParseExact(source, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException ex)
            {
                NLogLogger.Instance.Log(ex);
                return null;
            }
            catch (FormatException ex)
            {
                NLogLogger.Instance.Log(ex);
                return null;
            }
        }
    }
}
