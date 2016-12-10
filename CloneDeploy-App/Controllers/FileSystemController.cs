﻿using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using CloneDeploy_App.Controllers.Authorization;
using CloneDeploy_Entities;
using CloneDeploy_Entities.DTOs;
using CloneDeploy_Services;
using CloneDeploy_Services.Helpers;


namespace CloneDeploy_App.Controllers
{
    public class FileSystemController :ApiController
    {
        [HttpGet]
        [CustomAuth(Permission = "ComputerSearch")]
        public ApiBoolResponseDTO BootSdiExists()
        {

            return new ApiBoolResponseDTO
            {
                Value = new FileOps().FileExists(Settings.TftpPath + Path.DirectorySeparatorChar + "boot" +
                                                         Path.DirectorySeparatorChar + "boot.sdi")
            };
            
        }

        [HttpGet]
        [CustomAuth(Permission = "ComputerSearch")]
        public ApiStringResponseDTO ReadFileText(string path)
        {

            return new ApiStringResponseDTO
            {
                Value = new FileOps().ReadAllText(path)
            };

        }

        [HttpGet]
        [CustomAuth(Permission = "ComputerSearch")]
        public IEnumerable<string> GetKernels()
        {


            return Utility.GetKernels();

        }

        [HttpGet]
        [CustomAuth(Permission = "ComputerSearch")]
        public IEnumerable<string> GetBootImages()
        {

            return Utility.GetBootImages();
        }

        [HttpGet]
        [CustomAuth(Permission = "ComputerSearch")]
        public List<string> GetLogs()
        {


            return Utility.GetLogs();


        }

        [HttpGet]
        [CustomAuth(Permission = "ComputerSearch")]
        public MunkiPackageInfoEntity GetPlist(string file)
        {
            return new Utility().ReadPlist(file);
        }

        [HttpGet]
        [CustomAuth(Permission = "ComputerSearch")]
        public List<FileInfo> GetMunkiResources(string resourceType)
        {
            return new Utility().GetMunkiResources(resourceType);
        }


        [HttpGet]
        [CustomAuth(Permission = "ComputerSearch")]
        public ApiBoolResponseDTO SetUnixPermissions(string path)
        {
           new FileOps().SetUnixPermissions(path);
            return new ApiBoolResponseDTO() {Value = true};
        }

        [HttpGet]
        [CustomAuth(Permission = "ComputerSearch")]
        public List<string> GetScripts(string type)
        {


            return Utility.GetScripts(type);


        }

        [HttpGet]
        [CustomAuth(Permission = "ComputerSearch")]
        public List<string> GetThinImages()
        {
            return Utility.GetThinImages();
        }

        [Authorize]
        public DpFreeSpaceDTO GetDpFreeSpace()
        {
            return new FilesystemServices().GetDpFreeSpace();
        }
        
    }
}