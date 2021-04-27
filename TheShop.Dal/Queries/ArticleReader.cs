using TheShop.Domain.Model;
using TheShop.Domain.Queries;

namespace TheShop.Dal.InMemory.Queries
{
    public class ArticleReader : IArticleReader
    {
        private readonly IEntityRepository<Article> _articleRepository;

        public ArticleReader(IEntityRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public Article GetById(long id)
        {
            return _articleRepository.GetById(id);
        }
    }
}
