create view votesbyuserid 
with schemabindING
as

Select VoteID, PostID, CreationDate, vt.Name, UserId
from dbo.Votes v
	inner join dbo.VoteTypes vt on v.VoteTypeId = vt.VoteTypeId
Where Userid is not null

CREATE UNIQUE CLUSTERED INDEX vwi_votebyuserid ON votesbyuserid (VoteID)
CREATE NonCLUSTERED INDEX vwi_votebyuserid_getuserid ON votesbyuserid (UserId)
INCLUDE (VoteID, PostID, CreationDate, name)


Select *
from dbo.votesbyuserid
Where userid = 23354

Select *
from dbo.votesbyuserid (noexpand)
Where userid = 23354
