using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Finance.Queries;

public class GetDueDebitorsQuery
{
	private readonly AccountRepository _repository;

	public GetDueDebitorsQuery(AccountRepository repository)
	{
		_repository = repository;
	}

	public async Task<Dictionary<Debitor, List<Sale>>> ExecuteAsync(int tenantId)
	{
		return await _repository.GetDueSalesByDebitorAsync(tenantId);
	}
}