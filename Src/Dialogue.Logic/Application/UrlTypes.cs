﻿using System.Web;
using Dialogue.Logic.Constants;

namespace Dialogue.Logic.Application
{
    public static class UrlTypes
    {
        public enum UrlType
        {
            Topic,
            Member,
            Login,
            Register,
            Dialogue,
            Leaderboard,
            TopicCreate,
            EditMember,
            SearchMembers,
            PrivateMessageCreate,
            TopicsRss
        }

        public static string UrlTypeName(UrlType e)
        {
            switch (e)
            {
                case UrlType.Topic:
                    return Dialogue.Settings().TopicUrlName;
                case UrlType.Member:
                    return Dialogue.Settings().MemberUrlName;
                case UrlType.Login:
                    return Dialogue.Settings().LoginUrl;
                case UrlType.Register:
                    return Dialogue.Settings().RegisterUrl;
                case UrlType.TopicCreate:
                    return Dialogue.Settings().CreateTopicUrl;
                case UrlType.EditMember:
                    return Dialogue.Settings().EditMemberUrl;
                case UrlType.SearchMembers:
                    return Dialogue.Settings().SearchMembersUrl;
                case UrlType.PrivateMessageCreate:
                    return Dialogue.Settings().CreatePrivateMessageUrl;
                case UrlType.Leaderboard:
                    return GenerateUrl(UrlType.Dialogue, AppConstants.PageUrlLeaderboard);
                case UrlType.TopicsRss:
                    return GenerateUrl(UrlType.Dialogue, AppConstants.PageUrlTopicsRss);
                default:
                    return Dialogue.Settings().DialogueUrlName;
            }
        }

        public static string GenerateUrl(UrlType e, string slug)
        {
            return VirtualPathUtility.ToAbsolute(string.Format("~{0}{1}/{2}/", Dialogue.Settings().ForumRootUrl, UrlTypeName(e), HttpUtility.HtmlDecode(slug)));            
        }

        public static string GenerateUrl(UrlType e)
        {
            return VirtualPathUtility.ToAbsolute(string.Format("~{0}", UrlTypeName(e)));
        }

        public static string GenerateFileUrl(string filePath)
        {
            return VirtualPathUtility.ToAbsolute(filePath);
        }
    }
}