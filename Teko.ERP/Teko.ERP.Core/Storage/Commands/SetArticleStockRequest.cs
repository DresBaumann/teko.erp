namespace Teko.ERP.Core.Storage.Commands;

public class SetArticleStockRequest
{
    public int ArticleId { get; set; }
    public int LocationId { get; set; }

    public int Quantity { get; set; }
}