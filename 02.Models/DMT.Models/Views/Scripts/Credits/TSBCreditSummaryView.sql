CREATE VIEW TSBCreditSummaryView
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
		 , ((
			 SELECT IFNULL(SUM(AmountST25), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountST25), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 3
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Exchange = 2, Returns = 3, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountST25), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountST25), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountST25
		 , ((
			 SELECT IFNULL(SUM(AmountST50), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountST50), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountST50), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountST50), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountST50
		 , ((
			 SELECT IFNULL(SUM(AmountBHT1), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountBHT1), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT1), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT1), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountBHT1
		 , ((
			 SELECT IFNULL(SUM(AmountBHT2), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountBHT2), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT2), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT2), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountBHT2
		 , ((
			 SELECT IFNULL(SUM(AmountBHT5), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountBHT5), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT5), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT5), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountBHT5
		 , ((
			 SELECT IFNULL(SUM(AmountBHT10), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountBHT10), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT10), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT10), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountBHT10
		 , ((
			 SELECT IFNULL(SUM(AmountBHT20), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountBHT20), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT20), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT20), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountBHT20
		 , ((
			 SELECT IFNULL(SUM(AmountBHT50), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountBHT50), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT50), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT50), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountBHT50
		 , ((
			 SELECT IFNULL(SUM(AmountBHT100), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountBHT100), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT100), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT100), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountBHT100
		 , ((
			 SELECT IFNULL(SUM(AmountBHT500), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountBHT500), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT500), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT500), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountBHT500
		 , ((
			 SELECT IFNULL(SUM(AmountBHT1000), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 0 
					 OR TSBCreditTransaction.TransactionType = 1
					 OR TSBCreditTransaction.TransactionType = 12
					) -- Initial = 0, Received = 1, Replace In = 12
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) -
			(
			 SELECT IFNULL(SUM(AmountBHT1000), 0) 
			   FROM TSBCreditTransaction 
			  WHERE (   TSBCreditTransaction.TransactionType = 2
					 OR TSBCreditTransaction.TransactionType = 11
			        ) -- Returns = 2, Replace Out = 11
				AND TSBCreditTransaction.TSBId = TSB.TSBId
			) - 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT1000), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 1 -- Borrow
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			) + 
			(
			 SELECT IFNULL(SUM(UserCreditTransaction.AmountBHT1000), 0) 
			   FROM UserCreditTransaction, UserCreditBalance 
			  WHERE UserCreditBalance.TSBId = TSB.TSBId
				AND UserCreditTransaction.TransactionType = 2 -- Return
				AND UserCreditTransaction.UserCreditId = UserCreditBalance.UserCreditId
			)) AS AmountBHT1000
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
