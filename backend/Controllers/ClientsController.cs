using AutoMapper;
using backend.DTOs.Client;
using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly Repository<Client> repository;
        private readonly IMapper mapper;
        public ClientsController(Repository<Client> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        
        // GET: api/clients
        [HttpGet]
        public async Task<ActionResult<List<ClientDTO>>> GetAll()
        {
            try
            {
                var initialTimeRequest = DateTime.Now.Millisecond;
               
                var clients = await repository.Get();

                var totalTimeRequest = DateTime.Now.Millisecond - initialTimeRequest;
                Console.WriteLine("Tiempo total request ---> " + totalTimeRequest + "ms");

                return Ok(this.mapper.Map<List<ClientDTO>>(clients));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/clients/2
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetById(int id)
        {
            try
            {
                var initialTimeRequest = DateTime.Now.Millisecond;
               
                var clients = await repository.Get(c => c.Id == id);

                var totalTimeRequest = DateTime.Now.Millisecond - initialTimeRequest;
                Console.WriteLine("Tiempo total request ---> " + totalTimeRequest + "ms");

                return Ok(this.mapper.Map<ClientDTO>(clients.FirstOrDefault()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/clients
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientCreateDTO clientDTO)
        {
            try
            {
                var initialTimeRequest = DateTime.Now.Millisecond;

                var newClient = mapper.Map<Client>(clientDTO);
                await repository.Add(newClient);
               
                var totalTimeRequest = DateTime.Now.Millisecond - initialTimeRequest;
                Console.WriteLine("Tiempo total request ---> " + totalTimeRequest + "ms");

                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/clients
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientUpdateDTO clientDTO )
        {
            try
            {
                var initialTimeRequest = DateTime.Now.Millisecond;

                var client = await repository.Get(c => c.Id == id);
                var clientToUpdate = mapper.Map(clientDTO, client.FirstOrDefault());
                await repository.Update(clientToUpdate);

                var totalTimeRequest = DateTime.Now.Millisecond - initialTimeRequest;
                Console.WriteLine("Tiempo total request ---> " + totalTimeRequest + "ms");

                return NoContent();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/clients
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var initialTimeRequest = DateTime.Now.Millisecond;

                var client = await repository.Get(c => c.Id == id);
                await repository.Delete(client.FirstOrDefault());

                var totalTimeRequest = DateTime.Now.Millisecond - initialTimeRequest;
                Console.WriteLine("Tiempo total request ---> " + totalTimeRequest + "ms");

                return NoContent();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
