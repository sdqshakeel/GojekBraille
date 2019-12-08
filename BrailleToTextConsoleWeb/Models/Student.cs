using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrailleToTextConsoleWeb.Models
{
    public class DetectedLanguage
    {
        public string name { get; set; }
        public string iso6391Name { get; set; }
        public double score { get; set; }
    }
    public class Match
    {
        public double? wikipediaScore { get; set; }
        public double? entityTypeScore { get; set; }
        public string text { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class Entity
    {
        public string name { get; set; }
        public List<Match> matches { get; set; }
        public string wikipediaLanguage { get; set; }
        public string wikipediaId { get; set; }
        public string wikipediaUrl { get; set; }
        public string bingId { get; set; }
        public string type { get; set; }
        public object subType { get; set; }
    }
    public class Document
    {
        public string id { get; set; }
        public double score { get; set; }
        public List<DetectedLanguage> detectedLanguages { get; set; }
        public List<Entity> entities { get; set; }

    }

    public class RootObject
    {
        public List<Document> documents { get; set; }
        public List<object> errors { get; set; }
    }

    public class RootObject2
    {
        public List<Document> documents { get; set; }
        public List<object> errors { get; set; }
    }
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        public int Age { get; set; }
        public bool isNewlyEnrolled { get; set; }
        public string Password { get; set; }
    }
}