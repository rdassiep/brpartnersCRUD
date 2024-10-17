using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using brpartnersCRUD.Data;
using brpartnersCRUD.Models;
using brpartnersCRUD.DTO;

namespace brpartnersCRUD.Controllers
{
    public class ClientsController : Controller
    {
        private readonly BrpartnersCRUDContext _context;

        public ClientsController(BrpartnersCRUDContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            if (_context.Client != null)
            {
                var clients = new List<DTOClient>();
                foreach (var client in _context.Client)
                {
                    clients.Add(new DTOClient
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Email = client.Email,
                        Document = client.Document
                    });
                }
                return View(clients);
            }
            return Problem("Entity set 'brpartnersCRUDContext.Client'  is null.");

        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);

            if (client == null)
            {
                return NotFound();
            }
            var addresses = _context.Address.Where(a => a.ClientId == client.Id);
            var fiscalAddress = addresses.FirstOrDefault(a => a.Type == Models.AddressType.Fiscal);
            var fiscalAddressDTO = new DTOAddress
            {
             
                Street = fiscalAddress.Street,
                Number = fiscalAddress.Number,
                ZipCode = fiscalAddress.ZipCode,
            };
            var billingAddress = addresses.FirstOrDefault(a => a.Type == Models.AddressType.Billing);
            var billingAddressDTO = new DTOAddress
            {

                Street = billingAddress.Street,
                Number = billingAddress.Number,
                ZipCode = billingAddress.ZipCode,
            };
            var shippingAddress = addresses.FirstOrDefault(a => a.Type == Models.AddressType.Shipping);
            var shippingAddressDTO = new DTOAddress
            {

                Street = shippingAddress.Street,
                Number = shippingAddress.Number,
                ZipCode = shippingAddress.ZipCode,
            };

            var clientDTO = new DTOClient
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Document = client.Document,
                FiscalAddress = fiscalAddressDTO,
                BillingAddress = billingAddressDTO,
                ShippingAddress = shippingAddressDTO
            };
            return View(clientDTO);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DTOClient clientDTO)
        {
            if (ModelState.IsValid)
            {
                var client = new Client {
                    Name = clientDTO.Name,
                    Email = clientDTO.Email,
                    Document = clientDTO.Document
                };
                var result = _context.Add(client);
                var fiscalAddress = new Address {
                    Client = result.Entity,
                    ClientId = result.Entity.Id,
                    Street = clientDTO.FiscalAddress.Street,
                    Number = clientDTO.FiscalAddress.Number,
                    ZipCode = clientDTO.FiscalAddress.ZipCode,
                    Type = Models.AddressType.Fiscal
                };
                var billingAddress = new Address
                {
                    Client = result.Entity,
                    ClientId = result.Entity.Id,
                    Street = clientDTO.BillingAddress.Street,
                    Number = clientDTO.BillingAddress.Number,
                    ZipCode = clientDTO.BillingAddress.ZipCode,
                    Type = Models.AddressType.Billing
                };
                var shippingAddress = new Address
                {
                    Client = result.Entity,
                    ClientId = result.Entity.Id,
                    Street = clientDTO.ShippingAddress.Street,
                    Number = clientDTO.ShippingAddress.Number,
                    ZipCode = clientDTO.ShippingAddress.ZipCode,
                    Type = Models.AddressType.Shipping
                };
                _context.Add(fiscalAddress);
                _context.Add(billingAddress);
                _context.Add(shippingAddress);

                //client.Addresses.Add(fiscalAddress);
                //client.Addresses.Add(billingAddress);
                //client.Addresses.Add(shippingAddress);

                //_context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientDTO);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            var addresses = _context.Address.Where(a => a.ClientId == client.Id);
            var fiscalAddress = addresses.FirstOrDefault(a => a.Type == Models.AddressType.Fiscal);
            var fiscalAddressDTO = new DTOAddress
            {
                Id = fiscalAddress.Id,
                Street = fiscalAddress.Street,
                Number = fiscalAddress.Number,
                ZipCode = fiscalAddress.ZipCode,
            };
            var billingAddress = addresses.FirstOrDefault(a => a.Type == Models.AddressType.Billing);
            var billingAddressDTO = new DTOAddress
            {
                Id = billingAddress.Id,
                Street = billingAddress.Street,
                Number = billingAddress.Number,
                ZipCode = billingAddress.ZipCode,
            };
            var shippingAddress = addresses.FirstOrDefault(a => a.Type == Models.AddressType.Shipping);
            var shippingAddressDTO = new DTOAddress
            {
                Id = shippingAddress.Id,
                Street = shippingAddress.Street,
                Number = shippingAddress.Number,
                ZipCode = shippingAddress.ZipCode,
            };

            var clientDTO = new DTOClient
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Document = client.Document,
                FiscalAddress = fiscalAddressDTO,
                BillingAddress = billingAddressDTO,
                ShippingAddress = shippingAddressDTO
            };

            return View(clientDTO);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DTOClient clientDTO)
        {
            var client = new Client
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name,
                Email = clientDTO.Email,
                Document = clientDTO.Document
            };
            
            var fiscalAddress = new Address
            {
                Client = client,
                ClientId = client.Id,
                Id = clientDTO.FiscalAddress.Id,
                Street = clientDTO.FiscalAddress.Street,
                Number = clientDTO.FiscalAddress.Number,
                ZipCode = clientDTO.FiscalAddress.ZipCode,
                Type = Models.AddressType.Fiscal
            };
            var billingAddress = new Address
            {
                Client = client,
                ClientId = client.Id,
                Id = clientDTO.BillingAddress.Id,
                Street = clientDTO.BillingAddress.Street,
                Number = clientDTO.BillingAddress.Number,
                ZipCode = clientDTO.BillingAddress.ZipCode,
                Type = Models.AddressType.Billing
            };
            var shippingAddress = new Address
            {
                Client = client,
                ClientId = client.Id,
                Id = clientDTO.ShippingAddress.Id,
                Street = clientDTO.ShippingAddress.Street,
                Number = clientDTO.ShippingAddress.Number,
                ZipCode = clientDTO.ShippingAddress.ZipCode,
                Type = Models.AddressType.Shipping
            };

            if (id != client.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    _context.Update(fiscalAddress);
                    _context.Update(billingAddress);
                    _context.Update(shippingAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Client == null)
            {
                return Problem("Entity set 'brpartnersCRUDContext.Client'  is null.");
            }
            var client = await _context.Client.FindAsync(id);
            if (client != null)
            {
                var addresses = _context.Address.Where(a => a.ClientId == client.Id);
                foreach (var address in addresses)
                {
                    _context.Address.Remove(address);
                }
                _context.Client.Remove(client);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
