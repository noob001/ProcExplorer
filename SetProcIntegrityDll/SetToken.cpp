#include "SetToken.h"

bool SetTokenIntegrity(long IntLvl)
{


	static SID_IDENTIFIER_AUTHORITY mandatoryLabelAuthority = SECURITY_MANDATORY_LABEL_AUTHORITY;

	UCHAR newSidBuffer[FIELD_OFFSET(SID, SubAuthority) + sizeof(ULONG)];
	PSID newSid;
	TOKEN_MANDATORY_LABEL mandatoryLabel;

	newSid = (PSID)newSidBuffer;
	RtlInitializeSid(newSid, &mandatoryLabelAuthority, 1);
	*RtlSubAuthoritySid(newSid, 0) = MANDATORY_LEVEL_TO_MANDATORY_RID(selectedItem->Id);
	mandatoryLabel.Label.Sid = newSid;
	mandatoryLabel.Label.Attributes = SE_GROUP_INTEGRITY;
}