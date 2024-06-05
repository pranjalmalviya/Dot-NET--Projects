using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;
using Visitor_Security_Clearance_System.Common;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Entity;
using Visitor_Security_Clearance_System.Entity;
using Container = Microsoft.Azure.Cosmos.Container;


namespace Visitor_Security_Clearance_System.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
    {
        public readonly CosmosClient _cosmosClient;
        private readonly Container _container;
        public CosmosDBService()

        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndPoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
        }

        //Visitor
        public async Task<VisitorEntity> RegisterVisitor(VisitorEntity visitor)
        {
            var response = await _container.CreateItemAsync(visitor);
            return response;
        }

        public async Task<VisitorEntity> GetVisitorByEmail(string email)
        {
            var visitor = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(a => a.Email == email && !a.Archived
            && a.Active && a.DocumentType == Credentials.VisitorDocumentType).FirstOrDefault();
            return visitor;
        }

        public async Task<VisitorEntity> GetVisitorByUId(string uId)
        {
            var visitor = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(a => a.UId == uId && !a.Archived
            && a.Active && a.DocumentType == Credentials.VisitorDocumentType).FirstOrDefault();
            return visitor;
        }

        public async Task ReplaceAsync(dynamic entity)
        {
            var response = await _container.ReplaceItemAsync(entity, entity.Id);
        }
        

        //Security

        public async Task<SecurityEntity> RegisterSecurity(SecurityEntity security)
        {
            var response = await _container.CreateItemAsync(security);
            return response;
        }

        public async Task<SecurityEntity> GetSecurityByEmail(string email)
        {
            var security = _container.GetItemLinqQueryable<SecurityEntity>(true).Where(a => a.Email == email && !a.Archived
            && a.Active && a.DocumentType == Credentials.SecurityDocumentType).FirstOrDefault();
            return security;
        }

        public async Task<SecurityEntity> GetSecurityByUId(string uId)
        {
            var security = _container.GetItemLinqQueryable<SecurityEntity>(true).Where(a => a.UId == uId && !a.Archived
            && a.Active && a.DocumentType == Credentials.SecurityDocumentType).FirstOrDefault();
            return security;
        }

        //Manager
        public async Task<ManagerEntity> RegisterManager(ManagerEntity manager)
        {
            var response = await _container.CreateItemAsync(manager);
            return response;
        }

        public async Task<ManagerEntity> GetManagerByEmail(string email)
        {
            var manager= _container.GetItemLinqQueryable<ManagerEntity>(true).Where(a => a.Email == email && !a.Archived
            && a.Active && a.DocumentType == Credentials.ManagerDocumentType).FirstOrDefault();
            return manager;
        }
        public async Task<ManagerEntity> GetManagerByUId(string uId)
        {
            var member = _container.GetItemLinqQueryable<ManagerEntity>(true).Where(a => a.UId == uId && !a.Archived
            && a.Active && a.DocumentType == Credentials.ManagerDocumentType).FirstOrDefault();
            return member;
        }


        //Office
        public async Task<OfficeEntity> RegisterOffice(OfficeEntity office)
        {
            var response = await _container.CreateItemAsync(office);
            return response;
        }
        public async Task<OfficeEntity> GetOfficeByUId(string uId)
        {
            var office = _container.GetItemLinqQueryable<OfficeEntity>(true).Where(a => a.UId == uId && !a.Archived
            && a.Active && a.DocumentType == Credentials.OfficeDocumentType).FirstOrDefault();
            return office;
        }

       

        //login
        public async Task<UserLoginDTO> GetUserByEmail(string email)
        {
            var response = _container.GetItemLinqQueryable<UserEntity>(true)
                                    .Where(a => a.Email == email)
                                    .Select(u => new UserLoginDTO { Email = u.Email, Role = u.Role })
                                    .FirstOrDefault();
            return response;
        }


        
        /*public async Task<UserLoginDTO> GetUserAsync(string uId, string email, string role)
        {


            
            var query = _container.GetItemLinqQueryable<UserLoginDTO>(true)
                                   .Where(u => u.UId == uId && u.Email == email && u.Role == role)
                                  

            
           

            return query;
        }
       */


        //pass
        public async Task<PassEntity> CreatePass(PassEntity pass)
        {
            var response = await _container.CreateItemAsync(pass);
            return response;
        }


        public async Task<PassEntity> GetPassByVisitorId(string visitorId)
        {
            var pass = _container.GetItemLinqQueryable<PassEntity>(true).Where(a => a.VisitorID == visitorId && !a.Archived
            && a.Active && a.DocumentType == Credentials.PassDocumentType).FirstOrDefault();
            return pass;
        }


        //visitor as per pass status
        public async Task<List<VisitorEntity>> GetVisitorsByStatus(string status)
        {
            var response = _container.GetItemLinqQueryable<VisitorEntity>(true)
                .Where(a => a.Status == status && a.DocumentType == Credentials.VisitorDocumentType)
                .ToList();

            return response;
        }


        //Geeting pass id
       
        public async Task<PassEntity> GetPassById(string uId)
        {
            var response = _container.GetItemLinqQueryable<PassEntity>(true)
                                           .Where(a => a.UId == uId).FirstOrDefault();
            return response;
        }


        public async Task<PassEntity> UpdatePass(PassEntity passEntity)
        {
           //Replace
                var response = await _container.ReplaceItemAsync(passEntity, passEntity.UId, new PartitionKey(passEntity.UId));
                return response.Resource;
            
            
            
        }



    }
}
