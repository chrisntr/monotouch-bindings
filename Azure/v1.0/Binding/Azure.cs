using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace Azure
{
	[BaseType (typeof (NSObject))]
	[Model]
	interface AuthenticationDelegate {
		[Abstract]
		[Export ("loginDidFailWithError:")]
		void LoginDidFailWithError (NSError error);

	}

	[BaseType (typeof (NSObject))]
	interface AuthenticationCredential {
		[Export ("proxyURL")]
		NSUrl ProxyURL { get;  }

		[Export ("token")]
		string Token { get;  }

		[Export ("accountName")]
		string AccountName { get;  }

		[Export ("accessKey")]
		string AccessKey { get;  }

		[Export ("tableServiceURL")]
		string TableServiceURL { get;  }

		[Export ("blobServiceURL")]
		string BlobServiceURL { get;  }

		[Export ("usesProxy")]
		bool UsesProxy ();

		[Static]
		[Export ("credentialWithAzureServiceAccount:accessKey:")]
		AuthenticationCredential CreateCredentials (string accountName, string accessKey);

		[Static]
		[Export ("authenticateCredentialSynchronousWithProxyURL:user:password:error:")]
		AuthenticationCredential AuthenticateCredentials (NSUrl proxyURL, string user, string password, NSError returnError);

		[Static]
		[Export ("authenticateCredentialSynchronousWithProxyURL:tableServiceURL:blobServiceURL:user:password:error:")]
		AuthenticationCredential AuthenticateCredentials (NSUrl proxyURL, NSUrl tablesURL, NSUrl blobsURL, string user, string password, NSError returnError);

		[Static]
		[Export ("authenticateCredentialWithProxyURL:user:password:delegate:")]
		AuthenticationCredential AuthenticateCredentials (NSUrl proxyURL, string user, string password, AuthenticationDelegate aDelegate);

		/*[Static]
		[Export ("authenticateCredentialWithProxyURL:user:password:withBlock:NSError*))block")]
		AuthenticationCredential AuthenticateCredentialWithProxyURLuserpasswordwithBlockNSError*))block (NSUrl proxyURL, string user, string password, void (^ (NSError*))block);*/

	}
	
	[BaseType (typeof (NSObject))]
	interface Blob {
		[Export ("name")]
		string Name { get;  }

		[Export ("URL")]
		NSUrl Url { get;  }

		[Export ("container")]
		BlobContainer Container { get;  }

	}
	
	[BaseType (typeof (NSObject))]
	interface BlobContainer {
		[Export ("name")]
		string Name { get; set;  }

		[Export ("URL")]
		NSUrl Url { get;  }

		[Export ("metadata")]
		string Metadata { get;  }

		[Export ("initContainerWithName:URL:metadata:")]
		IntPtr Constructor (string name, string url, string metadata);
		//NSObject InitContainerWithNameURLmetadata (string name, string URL, string metadata);

	}
	
	[BaseType (typeof (NSObject))]
	interface CloudStorageClient {
		
		//[Export ("id<CloudStorageClientDelegate>delegate")]
		//CloudStorageClientDelegate delegat;

		[Export ("getBlobContainers")]
		void GetBlobContainers ();

		//[Export ("getBlobContainersWithBlock:NSArray*,NSError*))block")]
		//void GetBlobContainersWithBlockNSArray*,NSError*))block (void (^ (NSArray*,, );

		[Export ("addBlobContainer:")]
		bool AddBlobContainer (string containerName);

		//[Export ("addBlobContainer:withBlock:NSError*))block")]
		//bool AddBlobContainerwithBlockNSError*))block (string containerName, void (^ (NSError, );

		[Export ("deleteBlobContainer:")]
		bool DeleteBlobContainer (BlobContainer container);

		//[Export ("deleteBlobContainer:withBlock:NSError*))block")]
		//bool DeleteBlobContainerwithBlockNSError*))block (BlobContainer container, void (^ (NSError, );

		[Export ("getBlobs:")]
		void GetBlobs (BlobContainer container);

		//[Export ("getBlobs:withBlock:NSArray*,NSError*))block")]
		//void GetBlobswithBlockNSArray*,NSError*))block (BlobContainer container, void (^ (NSArray, );

		[Export ("getBlobData:")]
		void GetBlobData (Blob blob);

		//[Export ("getBlobData:withBlock:NSData*,NSError*))block")]
		//void GetBlobDatawithBlockNSData*,NSError*))block (Blob blob, void (^ (NSData, );

		[Export ("addBlobToContainer:blobName:contentData:contentType:")]
		void AddBlobToContainerblobNamecontentDatacontentType (BlobContainer container, string blobName, NSData contentData, string contentType);

		//[Export ("addBlobToContainer:blobName:contentData:contentType:withBlock:NSError*))block")]
		//void AddBlobToContainerblobNamecontentDatacontentTypewithBlockNSError*))block (BlobContainer container, string blobName, NSData contentData, string contentType, void (^ (NSError, );

		[Export ("deleteBlob:")]
		void DeleteBlob (Blob blob);

		//[Export ("deleteBlob:withBlock:NSError*))block")]
		//void DeleteBlobwithBlockNSError*))block (Blob blob, void (^ (NSError, );

		[Export ("getQueues")]
		void GetQueues ();

		//[Export ("getQueuesWithBlock:NSArray*,NSError*))block")]
		//void GetQueuesWithBlockNSArray*,NSError*))block (void (^ (NSArray*,, );

		[Export ("addQueue:")]
		void AddQueue (string queueName);

		//[Export ("addQueue:withBlock:NSError*))block")]
		//void AddQueuewithBlockNSError*))block (string queueName, void (^ (NSError, );

		[Export ("deleteQueue:")]
		void DeleteQueue (string queueName);

		//[Export ("deleteQueue:withBlock:NSError*))block")]
		//void DeleteQueuewithBlockNSError*))block (string queueName, void (^ (NSError, );

		[Export ("getQueueMessages:")]
		void GetQueueMessages (string queueName);

		//[Export ("getQueueMessages:withBlock:NSArray*,NSError*))block")]
		//void GetQueueMessageswithBlockNSArray*,NSError*))block (string queueName, void (^ (NSArray, );

		[Export ("getQueueMessage:")]
		void GetQueueMessage (string queueName);

		//[Export ("getQueueMessage:withBlock:QueueMessage*,NSError*))block")]
		//void GetQueueMessagewithBlockQueueMessage*,NSError*))block (string queueName, void (^ (QueueMessage, );

		[Export ("getQueueMessages:fetchCount:")]
		void GetQueueMessagesfetchCount (string queueName, int fetchCount);

		//[Export ("getQueueMessages:fetchCount:withBlock:NSArray*,NSError*))block")]
		//void GetQueueMessagesfetchCountwithBlockNSArray*,NSError*))block (string queueName, int fetchCount, void (^ (NSArray, );

		[Export ("peekQueueMessage:")]
		void PeekQueueMessage (string queueName);

		//[Export ("peekQueueMessage:withBlock:QueueMessage*,NSError*))block")]
		//void PeekQueueMessagewithBlockQueueMessage*,NSError*))block (string queueName, void (^ (QueueMessage, );

		[Export ("peekQueueMessages:fetchCount:")]
		void PeekQueueMessagesfetchCount (string queueName, int fetchCount);

		//[Export ("peekQueueMessages:fetchCount:withBlock:NSArray*,NSError*))block")]
		//void PeekQueueMessagesfetchCountwithBlockNSArray*,NSError*))block (string queueName, int fetchCount, void (^ (NSArray, );

		[Export ("deleteQueueMessage:queueName:")]
		void DeleteQueueMessagequeueName (QueueMessage queueMessage, string queueName);

		//[Export ("deleteQueueMessage:queueName:withBlock:NSError*))block")]
		//void DeleteQueueMessagequeueNamewithBlockNSError*))block (QueueMessage queueMessage, string queueName, void (^ (NSError, );

		[Export ("putMessageToQueue:queueName:")]
		void PutMessageToQueuequeueName (string message, string queueName);

		//[Export ("putMessageToQueue:queueName:withBlock:NSError*))block")]
		//void PutMessageToQueuequeueNamewithBlockNSError*))block (string message, string queueName, void (^ (NSError, );

		[Export ("getTables")]
		void GetTables ();

		//[Export ("getTablesWithBlock:NSArray*,NSError*))block")]
		//void GetTablesWithBlockNSArray*,NSError*))block (void (^ (NSArray, );

		[Export ("createTableNamed:")]
		void CreateTableNamed (string newTableName);

		//[Export ("createTableNamed:withBlock:NSError*))block")]
		//void CreateTableNamedwithBlockNSError*))block (string newTableName, void (^ (NSError, );

		[Export ("deleteTableNamed:")]
		void DeleteTableNamed (string tableName);

		//[Export ("deleteTableNamed:withBlock:NSError*))block")]
		//void DeleteTableNamedwithBlockNSError*))block (string tableName, void (^ (NSError, );

		[Export ("getEntities:")]
		void GetEntities (TableFetchRequest fetchRequest);

		//[Export ("getEntities:withBlock:NSArray*,NSError*))block")]
		//void GetEntitieswithBlockNSArray*,NSError*))block (TableFetchRequest fetchRequest, void (^ (NSArray, );

		[Export ("insertEntity:")]
		bool InsertEntity (TableEntity newEntity);

		//[Export ("insertEntity:withBlock:NSError*))block")]
		//bool InsertEntitywithBlockNSError*))block (TableEntity newEntity, void (^ (NSError, );

		[Export ("updateEntity:")]
		bool UpdateEntity (TableEntity existingEntity);

		//[Export ("updateEntity:withBlock:NSError*))block")]
		//bool UpdateEntitywithBlockNSError*))block (TableEntity existingEntity, void (^ (NSError, );

		[Export ("mergeEntity:")]
		bool MergeEntity (TableEntity existingEntity);

		//[Export ("mergeEntity:withBlock:NSError*))block")]
		//bool MergeEntitywithBlockNSError*))block (TableEntity existingEntity, void (^ (NSError, );

		[Export ("deleteEntity:")]
		bool DeleteEntity (TableEntity existingEntity);

		//[Export ("deleteEntity:withBlock:NSError*))block")]
		//bool DeleteEntitywithBlockNSError*))block (TableEntity existingEntity, void (^ (NSError, );

		[Static]
		[Export ("storageClientWithCredential:")]
		CloudStorageClient StorageClient (AuthenticationCredential credential);

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface CloudStorageClientDelegate {
		[Abstract]
		[Export ("storageClient:didFailRequest:withError:")]
		void StorageClientdidFailRequestwithError (CloudStorageClient client, NSUrlRequest request, NSError error);

		[Abstract]
		[Export ("storageClient:didGetBlobContainers:")]
		void StorageClientdidGetBlobContainers (CloudStorageClient client, NSArray containers);

		[Abstract]
		[Export ("storageClient:didAddBlobContainer:")]
		void StorageClientdidAddBlobContainer (CloudStorageClient client, string name);

		[Abstract]
		[Export ("storageClient:didDeleteBlobContainer:")]
		void StorageClientdidDeleteBlobContainer (CloudStorageClient client, BlobContainer name);

		[Abstract]
		[Export ("storageClient:didGetBlobs:inContainer:")]
		void StorageClientdidGetBlobsinContainer (CloudStorageClient client, NSArray blobs, BlobContainer container);

		[Abstract]
		[Export ("storageClient:didGetBlobData:blob:")]
		void StorageClientdidGetBlobDatablob (CloudStorageClient client, NSData data, Blob blob);

		[Abstract]
		[Export ("storageClient:didAddBlobToContainer:blobName:")]
		void StorageClientdidAddBlobToContainerblobName (CloudStorageClient client, BlobContainer container, string blobName);

		[Abstract]
		[Export ("storageClient:didDeleteBlob:")]
		void StorageClientdidDeleteBlob (CloudStorageClient client, Blob blob);

		[Abstract]
		[Export ("storageClient:didAddQueue:")]
		void StorageClientdidAddQueue (CloudStorageClient client, string queueName);

		[Abstract]
		[Export ("storageClient:didDeleteQueue:")]
		void StorageClientdidDeleteQueue (CloudStorageClient client, string queueName);

		[Abstract]
		[Export ("storageClient:didGetQueues:")]
		void StorageClientdidGetQueues (CloudStorageClient client, NSArray queues);

		[Abstract]
		[Export ("storageClient:didGetQueueMessage:")]
		void StorageClientdidGetQueueMessage (CloudStorageClient client, QueueMessage queueMessage);

		[Abstract]
		[Export ("storageClient:didGetQueueMessages:")]
		void StorageClientdidGetQueueMessages (CloudStorageClient client, NSArray queueMessages);

		[Abstract]
		[Export ("storageClient:didPeekQueueMessage:")]
		void StorageClientdidPeekQueueMessage (CloudStorageClient client, QueueMessage queueMessage);

		[Abstract]
		[Export ("storageClient:didPeekQueueMessages:")]
		void StorageClientdidPeekQueueMessages (CloudStorageClient client, NSArray queueMessages);

		[Abstract]
		[Export ("storageClient:didDeleteQueueMessage:queueName:")]
		void StorageClientdidDeleteQueueMessagequeueName (CloudStorageClient client, QueueMessage queueMessage, string queueName);

		[Abstract]
		[Export ("storageClient:didPutMessageToQueue:queueName:")]
		void StorageClientdidPutMessageToQueuequeueName (CloudStorageClient client, string message, string queueName);

		[Abstract]
		[Export ("storageClient:didGetTables:")]
		void StorageClientdidGetTables (CloudStorageClient client, NSArray tables);

		[Abstract]
		[Export ("storageClient:didCreateTableNamed:")]
		void StorageClientdidCreateTableNamed (CloudStorageClient client, string tableName);

		[Abstract]
		[Export ("storageClient:didDeleteTableNamed:")]
		void StorageClientdidDeleteTableNamed (CloudStorageClient client, string tableName);

		[Abstract]
		[Export ("storageClient:didGetEntities:fromTableNamed:")]
		void StorageClientdidGetEntitiesfromTableNamed (CloudStorageClient client, NSArray entities, string tableName);

		[Abstract]
		[Export ("storageClient:didInsertEntity:")]
		void StorageClientdidInsertEntity (CloudStorageClient client, TableEntity entity);

		[Abstract]
		[Export ("storageClient:didUpdateEntity:")]
		void StorageClientdidUpdateEntity (CloudStorageClient client, TableEntity entity);

		[Abstract]
		[Export ("storageClient:didMergeEntity:")]
		void StorageClientdidMergeEntity (CloudStorageClient client, TableEntity entity);

		[Abstract]
		[Export ("storageClient:didDeleteEntity:")]
		void StorageClientdidDeleteEntity (CloudStorageClient client, TableEntity entity);

	}
	
	
	[BaseType (typeof (NSObject))]
	interface Queue {
		[Export ("queueName")]
		string QueueName { get; set;  }

		[Export ("URL")]
		NSUrl Url { get;  }

		[Export ("initQueueWithName:URL:")]
		IntPtr Constructor (string queueName, string url);
		//NSObject InitQueueWithNameURL (string queueName, string URL);

	}
	
	
	[BaseType (typeof (NSObject))]
	interface QueueMessage {
		[Export ("messageId")]
		string MessageId { get;  }

		[Export ("insertionTime")]
		string InsertionTime { get;  }

		[Export ("expirationTime")]
		string ExpirationTime { get;  }

		[Export ("popReceipt")]
		string PopReceipt { get;  }

		[Export ("timeNextVisible")]
		string TimeNextVisible { get;  }

		[Export ("messageText")]
		string MessageText { get; set;  }

		[Export ("initQueueMessageWithMessageId:insertionTime:expirationTime:popReceipt:timeNextVisible:messageText:")]
		IntPtr Constructor (string messageId, string insertionTime, string expirationTime, string popReceipt, string timeNextVisible, string messageText);
		//NSObject InitQueueMessageWithMessageIdinsertionTimeexpirationTimepopReceipttimeNextVisiblemessageText (string messageId, string insertionTime, string expirationTime, string popReceipt, string timeNextVisible, string messageText);

	}


	[BaseType (typeof (NSObject))]
	interface TableEntity {
		[Export ("partitionKey")]
		string PartitionKey { get; set;  }

		[Export ("rowKey")]
		string RowKey { get; set;  }

		[Export ("timeStamp")]
		DateTime TimeStamp { get;  }

		[Export ("tableName")]
		string TableName ();

		[Export ("keys")]
		NSArray Keys ();

		[Export ("valueForKey:")]
		NSObject ValueForKey (string key);

		[Export ("setValue:forKey:")]
		void SetValueforKey (NSObject value, string key);

		[Static]
		[Export ("createEntityForTable:")]
		TableEntity CreateEntity (string table);

	}



	[BaseType (typeof (NSObject))]
	interface TableFetchRequest {
		[Export ("partitionKey")]
		string PartitionKey { get; set;  }

		[Export ("rowKey")]
		string RowKey { get; set;  }

		[Export ("filter")]
		string Filter { get; set;  }

		[Export ("topRows")]
		int TopRows { get; set;  }

		[Export ("tableName")]
		string TableName ();

		[Static]
		[Export ("fetchRequestForTable:")]
		TableFetchRequest FetchRequest (string tableName);

		[Static]
		[Export ("fetchRequestForTable:predicate:error:")]
		TableFetchRequest FetchRequest (string tableName, NSPredicate predicate, NSError error);

	}


}