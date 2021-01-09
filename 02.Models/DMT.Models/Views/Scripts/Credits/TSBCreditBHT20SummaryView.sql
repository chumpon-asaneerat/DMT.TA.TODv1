/* Use in TSBCreditSummaryView */
CREATE VIEW TSBCreditBHT20SummaryView
AS
	SELECT TSB.TSBId
		 , TSB.TSBNameEN
		 , TSB.TSBNameTH

	  FROM TSB
