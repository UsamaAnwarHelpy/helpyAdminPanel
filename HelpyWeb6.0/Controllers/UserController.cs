using Firebase.Storage;
using FirebaseAdmin.Auth;
using HelpyAdmin.Data;
using HelpyAdmin.Models;
using HelpyAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirebaseAuth = Firebase.Auth.FirebaseAuth;

namespace HelpyAdmin.Controllers
{
    public class UserController : Controller
    {
        private readonly HelpyDbContext _context;

        public UserController(HelpyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (existingUser != null)
            {
                return Conflict(new { Message = "User already exists" });
            }
            else
            {
                //var userexistonfirebase = await FirebaseAuth.DefaultInstance.CreateUserAsync().GetUserByEmailAsync(model.Email);
                //if (userexistonfirebase != null)
                //{
                //    return Conflict(new { Message = "User already exists" });
                //}
                var userArgs = new UserRecordArgs()
                {
                    Email = model.Email,
                    EmailVerified = true,
                    Password = model.Password,
                    DisplayName = model.FullName,
                    Disabled = false,
                };
                UserRecord userRecord = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
                var user = new Users
                {
                    UGuid = userRecord.Uid,
                    FullName = model.FullName,
                    Email = model.Email,
                    PasswordHash = model.Password,
                    Gender = model.Gender,
                    Occupation = model.Occupation,
                    Age = model.Age,
                    Birthday = Convert.ToDateTime(model.Birthday),
                    Ethnicity = model.Ethnicity,
                    Sexuality = model.Sexuality,
                    Description = model.Description,
                    Intentions = model.Intentions,
                    Type = "Email",
                    IsActive = true,
                    SubscriptionId = 1,
                    ExpireDate = DateTime.Now.AddMonths(6),
                    PackageRenewalDate = DateTime.Now.AddMonths(6),
                    CreatedDate = DateTime.Now,
                    UserStatus = true,
                    City = model.City,
                    Country = model.Country,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    LookingFor = model.LookingFor,
                    isProfileVerified = false
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                // Create UserDetails entity
                var userDetail = new UserDetails
                {
                    UserId = user.Id,
                    UGuid = user.UGuid,
                    AgeRangeMin = 18,
                    AgeRangeMax = model.Age,
                    BodyType = model.BodyType,
                    Children = model.Children,
                    Drinking = model.Drinking,
                    Education = model.Education,
                    HeightInInches = model.HeightInInches,
                    Language = model.Language,
                    RelationshipStatus = model.RelationshipStatus,
                    Smoking = model.Smoking
                };
                await _context.UserDetails.AddAsync(userDetail);
                await _context.SaveChangesAsync();


                var userBillsDetails = model.SelectedItems.Select(item => new UserBillDetails
                {
                    UserId = user.Id,
                    BillId = item
                }).ToList();

                await _context.UserBillsDetails.AddRangeAsync(userBillsDetails);

                if (model.PublicImages != null)
                {
                    UploadImagesToFirebase(model, user);
                }

                if (model.PrivateImages != null)
                {
                    UploadImagesToFirebase(model, user);
                }

            }

            return Json(new { success = true, message = "Registration successful" });
        }
        public async Task UploadImagesToFirebase(UserRegistrationViewModel model, Users user)
        {
            if (model.PublicImages == null || !model.PublicImages.Any())
            {
                throw new ArgumentException("No public images provided");
            }

            var imageEntities = new List<Images>();
            var firebaseStorage = new FirebaseStorage("helpy-6f93d.appspot.com");

            foreach (var image in model.PublicImages)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{image.FileName}";

                try
                {
                    using (var stream = image.OpenReadStream())
                    {
                        if (stream == null || stream.Length == 0)
                        {
                            Console.WriteLine("File stream is invalid.");
                            throw new InvalidOperationException("Cannot read the file stream.");
                        }

                        // Upload the file
                        var uploadTask = await firebaseStorage
                            .Child("PublicImages")
                            .Child(user.UGuid)
                            .Child(uniqueFileName)
                            .PutAsync(stream);

                        // Get download URL
                        var downloadUrl = uploadTask;

                        // Log URL for debugging
                        Console.WriteLine($"Uploaded file. Download URL: {downloadUrl}");

                        // Create image metadata
                        var imageEntity = new Images
                        {
                            Name = image.FileName,
                            ImageLink = downloadUrl,
                            CreatedDate = DateTime.Now,
                            UpdateDate = DateTime.Now,
                            StatusID = 1, // Set based on your logic
                            UserId = user.Id
                        };

                        imageEntities.Add(imageEntity);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error uploading file {image.FileName}: {ex.Message}");
                    throw;
                }
            }

            // Save image metadata to the database
            try
            {
                _context.Images.AddRange(imageEntities);
                await _context.SaveChangesAsync();
                Console.WriteLine("Saved image metadata to the database.");
            }
            catch (Exception dbEx)
            {
                Console.WriteLine($"Error saving image metadata: {dbEx.Message}");
                throw;
            }
        }

        public IActionResult AllUsers()
        {
            var users = _context.Users.ToList();
            ViewData["users"] = users;
            var bills = _context.Bills.ToList();
            ViewData["Bills"] = bills;
            return View();
        }

    }
}
