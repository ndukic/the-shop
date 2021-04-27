using TheShop.Domain.Commands;
using TheShop.Domain.Model;

namespace TheShop.Dal.InMemory.Commands
{
    public class ArticleCreator : IArticleCreator
    {
        private readonly IEntityRepository<Article> _articleRepository;

        public ArticleCreator(IEntityRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Save(Article article)
        {
            _articleRepository.Save(article);
        }
    }
}
