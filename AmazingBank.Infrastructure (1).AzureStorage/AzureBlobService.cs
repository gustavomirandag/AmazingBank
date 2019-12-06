using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace AmazingBank.Infra.AzureStorage
{
    public class AzureBlobService
    {
        private CloudStorageAccount _cloudStorageAccount;

        public AzureBlobService()
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(Properties.Resources.
                ResourceManager.GetString("StorageAccountConnectionString"));
        }

        public string UploadFile(string fileName, Stream fileContent, string blobContainerName, string contentType)
        {
            //Crio um client para fazer acesso ao serviço de Blob
            var blobClient = _cloudStorageAccount.CreateCloudBlobClient();

            //Crio uma referência a um container mesmo que ele não existe
            var blobContainer = blobClient.GetContainerReference(blobContainerName);

            //Permite acesso anônimo a URL do blob
            blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            //Crio o blob caso não exista
            blobContainer.CreateIfNotExists();

            //Crio uma referência para o meu blob
            var blob = blobContainer.GetBlockBlobReference(fileName);

            //Defino o tipo de conteúdo do arquivo
            blob.Properties.ContentType = contentType;

            //Faço upload do meu blob
            blob.UploadFromStream(fileContent);

            //Retorno o endereço do blob
            return blob.Uri.AbsoluteUri;

        }


        public async Task<string> UploadFileAsync(string fileName, Stream fileContent, string blobContainerName, string contentType)
        {
            //Crio um client para fazer acesso ao serviço de Blob
            var blobClient = _cloudStorageAccount.CreateCloudBlobClient();

            //Crio uma referência a um container mesmo que ele não existe
            var blobContainer = blobClient.GetContainerReference(blobContainerName);

            //Permite acesso anônimo a URL do blob
            blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            //Crio o blob caso não exista
            blobContainer.CreateIfNotExists();

            //Crio uma referência para o meu blob
            var blob = blobContainer.GetBlockBlobReference(fileName);

            //Defino o tipo de conteúdo do arquivo
            blob.Properties.ContentType = contentType;

            //Faço upload do meu blob
            await blob.UploadFromStreamAsync(fileContent);

            //Retorno o endereço do blob
            return blob.Uri.AbsoluteUri;

        }

    }
}
