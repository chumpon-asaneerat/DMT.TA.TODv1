/* Use in TSBCreditSummaryView */
CREATE VIEW TSBCreditBHT10SummaryView
AS
	SELECT TSB.TSBId
		 , TSB.TSBNameEN
		 , TSB.TSBNameTH

	  FROM TSB
