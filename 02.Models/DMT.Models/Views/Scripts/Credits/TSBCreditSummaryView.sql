﻿CREATE VIEW TSBCreditSummaryView
AS
	SELECT TSB.TSBId
		 , TSB.TSBNameEN
		 , TSB.TSBNameTH
		 /* User Credit Borrow (1) - Return (2) */
		 , ((
			 SELECT (IFNULL(SUM(UserCreditTransaction.AmountST25), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountST50), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT1), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT2), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT5), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT10), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT20), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT50), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT100), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT500), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT1000), 0))
			   FROM UserCreditTransaction, UserCreditBalance
			  WHERE UserCreditTransaction.TransactionType = 1 -- Borrow = 1
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
				AND UserCreditBalance.TSBId = TSB.TSBId
			) -
			(
			 SELECT (IFNULL(SUM(UserCreditTransaction.AmountST25), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountST50), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT1), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT2), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT5), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT10), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT20), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT50), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT100), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT500), 0) +
					 IFNULL(SUM(UserCreditTransaction.AmountBHT1000), 0))
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditTransaction.TransactionType = 2 -- Returns = 2
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
				AND UserCreditBalance.TSBId = TSB.TSBId
			)) AS UserBHTTotal
		 /* TSB Credit Initial (0) + Received (1) +  ReplaceIn (12) - Exchange (2) - Return (3) - ReplaceOut (11) */
		 , AMT_ST25.AmountST25
		 , AMT_ST50.AmountST50
		 , AMT_BHT1.AmountBHT1
		 , AMT_BHT2.AmountBHT2
		 , AMT_BHT5.AmountBHT5
		 , AMT_BHT10.AmountBHT10
		 , AMT_BHT20.AmountBHT20
		 , AMT_BHT50.AmountBHT50
		 , AMT_BHT100.AmountBHT100
		 , AMT_BHT500.AmountBHT500
		 , AMT_BHT1000.AmountBHT1000
		 /* EXCHANGE, BORROW, ADDITIONAL */
		 , ((
			 SELECT IFNULL(SUM(ExchangeBHT), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(ExchangeBHT), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			)) AS ExchangeBHTTotal
		 , ((
			 SELECT IFNULL(SUM(BorrowBHT), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(BorrowBHT), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			)) AS BorrowBHTTotal
		 , ((
			 SELECT IFNULL(SUM(AdditionalBHT), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AdditionalBHT), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			)) AS AdditionalBHTTotal
	  FROM TSB
	     , TSBCreditST25SummaryView AS AMT_ST25
		 , TSBCreditST50SummaryView AS AMT_ST50
		 , TSBCreditBHT1SummaryView AS AMT_BHT1
		 , TSBCreditBHT2SummaryView AS AMT_BHT2
		 , TSBCreditBHT5SummaryView AS AMT_BHT5
		 , TSBCreditBHT10SummaryView AS AMT_BHT10
		 , TSBCreditBHT20SummaryView AS AMT_BHT20
		 , TSBCreditBHT50SummaryView AS AMT_BHT50
		 , TSBCreditBHT100SummaryView AS AMT_BHT100
		 , TSBCreditBHT500SummaryView AS AMT_BHT500
		 , TSBCreditBHT1000SummaryView AS AMT_BHT1000
	 WHERE AMT_ST25.TSBId = TSB.TSBId
	   AND AMT_ST50.TSBId = TSB.TSBId
	   AND AMT_BHT1.TSBId = TSB.TSBId
	   AND AMT_BHT2.TSBId = TSB.TSBId
	   AND AMT_BHT5.TSBId = TSB.TSBId
	   AND AMT_BHT10.TSBId = TSB.TSBId
	   AND AMT_BHT20.TSBId = TSB.TSBId
	   AND AMT_BHT50.TSBId = TSB.TSBId
	   AND AMT_BHT100.TSBId = TSB.TSBId
	   AND AMT_BHT500.TSBId = TSB.TSBId
	   AND AMT_BHT1000.TSBId = TSB.TSBId
