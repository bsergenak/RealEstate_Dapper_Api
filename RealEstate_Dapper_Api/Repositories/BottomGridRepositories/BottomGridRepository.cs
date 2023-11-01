using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;
        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async void CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into BottomGrid (Title, Icon, Description) values (@title, @icon, @description)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createBottomGridDto.Title);
            parameters.Add("@icon", createBottomGridDto.Icon);
            parameters.Add("@icon", createBottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrid Where BottomGridId = @bottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridId = @bottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "Update BottomGrid Set Title = @title, Icon = @icon, Description = @description where BottomGridId = @bottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateBottomGridDto.Title);
            parameters.Add("@icon", updateBottomGridDto.Icon);
            parameters.Add("@description", updateBottomGridDto.Description);
            parameters.Add("@bottomGridId", updateBottomGridDto.BottomGridId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
