using Amazon.S3;
using Amazon.S3.IO;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAccounting.Lib.Utility;

namespace DataMigrationUtility.Utility
{
    class AmazonS3Util
    {
        //private string bucketName = ConfigurationManager.AppSettings["BucketName"];
        #region "Temporory codde will move to app config or shared url"

        private string bucketName = "vatscanplus";
        private string awsAccessKeyId = "AKIAIBN3XVAYNL5G5UOQ";
        private string awsSecretAccessKey = "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";

        #endregion


        /// <summary>
        /// To upload object to AWS S3 Bucket
        /// </summary>
        /// <param name="transactionType"></param>
        /// <param name="currentClientId"></param>
        /// <param name="imageName"></param>
        /// <param name="imagePath"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public int UploadImagesToS3(string transactionType, int currentClientId, string imageName, string imagePath, string keyName)
        {
            try
            {
                using (var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.EUWest2))
                //  using (var client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest2))
                {
                    string objectKey = AppSettingsUtil.GetPathForKeyNameBucket(transactionType, currentClientId);
                    objectKey = objectKey + "/" + keyName;

                    //Creates PutObjectRequest of AmazonS3
                    var putObjectRequest = new PutObjectRequest
                    {
                        BucketName = bucketName,
                        Key = objectKey,
                        FilePath = imagePath,
                    };

                    //Adds an object to a bucket
                    client.PutObject(putObjectRequest);
                    File.Delete(imagePath);
                    return currentClientId;
                }

            }
            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
                return 0;
            }

        }

        /// <summary>
        /// To upload object to AWS S3 Bucket
        /// </summary>
        /// <param name="transactionType"></param>
        /// <param name="currentClientId"></param>
        /// <param name="imageName"></param>
        /// <param name="imagePath"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public int UploadImagesToS3ByTransferUtil(string transactionType, int currentClientId, string imageName, string imagePath, string keyName, Stream file)
        {
            try
            {
                using (var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.EUWest2))
                //  using (var client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest2))
                {
                    string objectKey = AppSettingsUtil.GetPathForKeyNameBucket(transactionType, currentClientId);
                    objectKey = objectKey + "/" + keyName;

                    using (var transferUtility = new TransferUtility(client))
                    {


                        //Creates PutObjectRequest of AmazonS3
                        var transferUtilityUploadRequest = new TransferUtilityUploadRequest
                        {
                            BucketName = bucketName,
                            Key = objectKey,
                            InputStream = file

                        };

                        //Adds an object to a bucket
                        transferUtility.Upload(transferUtilityUploadRequest);
                        MakeImagePublicReadOnly(objectKey);
                        File.Delete(imagePath);

                        return currentClientId;
                    }
                }

            }
            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
                return 0;
            }

        }

        public int UploadRecordAndBankStatementImagesToS3ByTransferUtil(string transactionType, int currentClientId, string imageName, string imagePath, string keyName, Stream file, string transferYear, string transferMonth)
        {
            try
            {
                using (var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.EUWest2))
                //  using (var client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest2))
                {
                    string objectKey = AppSettingsUtil.GetPathForKeyNameBucketForRecordAndBankStatementTransaction(transactionType, currentClientId, transferYear, transferMonth);
                    objectKey = objectKey + "/" + keyName;

                    using (var transferUtility = new TransferUtility(client))
                    {


                        //Creates PutObjectRequest of AmazonS3
                        var transferUtilityUploadRequest = new TransferUtilityUploadRequest
                        {
                            BucketName = bucketName,
                            Key = objectKey,
                            InputStream = file

                        };

                        //Adds an object to a bucket
                        transferUtility.Upload(transferUtilityUploadRequest);
                        MakeImagePublicReadOnly(objectKey);
                        File.Delete(imagePath);

                        return currentClientId;
                    }
                }

            }
            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
                return 0;
            }
        }


        /// <summary>
        ///Method to make an Image Public Readonly 
        /// </summary>
        /// <param name="objectKey"></param>
        public void MakeImagePublicReadOnly(string objectKey)
        {
            using (var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.EUWest2))
            {
                client.PutACL(new PutACLRequest
                {
                    BucketName = bucketName,
                    Key = objectKey,
                    CannedACL = S3CannedACL.PublicRead
                });
            }
        }


        /// <summary>
        /// To get Presigned url for the bucket with given object.
        /// </summary>
        /// <param name="objectKey">Object key of the object for which URL need to be generated.</param>
        /// <returns></returns>
        public string GetPreSignedURL(string objectKey)
        {
            try
            {
                using (var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.EUWest2))
                // using (var client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest2))
                {
                    var request = new GetPreSignedUrlRequest
                    {
                        BucketName = bucketName,
                        Key = objectKey,
                        Expires = DateTime.Now.AddMinutes(60),
                    };
                    var url = client.GetPreSignedURL(request);
                    return url;
                }
            }
            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
                return ex.Message.ToString();
            }

        }

        /// <summary>
        /// Copies object from one object key to another on amazon s3
        /// </summary>
        /// <param name="sourceObjectKey"></param>
        /// <param name="destinationObjectKey"></param>
        public void CopyObject(string sourceObjectKey, string destinationObjectKey)
        {
            try
            {
                using (var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.EUWest2))
                //using (var client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest2))
                {
                    var request = new CopyObjectRequest
                    {
                        SourceBucket = bucketName,
                        SourceKey = sourceObjectKey,
                        DestinationBucket = bucketName,
                        DestinationKey = destinationObjectKey
                    };

                    client.CopyObject(request);
                }
            }
            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }
        }

        /// <summary>
        /// Deletes object from amazon s3
        /// </summary>
        /// <param name="objectKey"></param>
        public void DeleteObject(string objectKey)
        {
            try
            {
                using (var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.EUWest2))
                // using (var client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest2))
                {
                    var request = new DeleteObjectRequest
                    {
                        BucketName = bucketName,
                        Key = objectKey
                    };

                    client.DeleteObject(request);
                }
            }
            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
            }
        }

        /// <summary>
        /// Finds an objects existance.
        /// </summary>
        /// <param name="keyName"></param>
        public bool FindObject(string keyName)
        {
            try
            {
                using (var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.EUWest2))
                //  using (var client = new AmazonS3Client(Amazon.RegionEndpoint.EUWest2))
                {
                    var s3FileInfo = new S3FileInfo(client, bucketName, keyName);
                    if (s3FileInfo.Exists)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Program.ErrorLogging(ex);
                return false;
            }

        }
    }
}
