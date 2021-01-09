/* Use in TSBCreditSummaryView */
CREATE VIEW TSBCreditBHT500SummaryView
AS
	SELECT TSB.TSBId
		 , TSB.TSBNameEN
		 , TSB.TSBNameTH

	  FROM TSB
