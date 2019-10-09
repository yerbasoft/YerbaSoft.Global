using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSWork.DTO.JiraObjs;

namespace CSWork.DTO.WorkDatas
{
    public class Issue : Base.ILazyLoadable<Issue, DTO.JiraObjs.Helpers.IssueFullData>
    {
        public class Changes
        {
            public string Property { get; set; }
            public object OldValue { get; set; }
            public object NewValue { get; set; }

            public string Header { get; set; }
            public string Body { get; set; }

            public Changes() { }
            public Changes(string name, object oldvalue, object newvalue)
            {
                this.Property = name;
                this.OldValue = oldvalue;
                this.NewValue = newvalue;
            }
        }

        public event Event<Issue> OnCompleteLoad;
        public event Event<Issue, IEnumerable<Changes>> OnChangeData;

        public JiraObjs.Issue Original;

        public string Key { get; set; }
        public string Status { get; set; } = "Cargando...";
        public string Priority { get; set; }
        public string Summary { get; set; } = "Cargando...";

        public List<Attachment> Adjuntos { get; set; } = new List<Attachment>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Transition> Transitions { get; set; }   // éste debe ser null cuando no está cargado

        [Newtonsoft.Json.JsonIgnore]
        public bool IsCompleteLoad { get; private set; }

        public Issue() { }
        public Issue(JiraObjs.Issue obj)
        {
            SetData(obj);
        }

        public Issue SetLazyData(DTO.JiraObjs.Helpers.IssueFullData data)
        {
            var changes = new List<Changes>();
            lock (this)
            {
                changes.AddRange(SetData(data.Issue));
                changes.AddRange(SetData(data.Transitions));
            }

            if (changes.Count > 0)
                this.OnChangeData?.Invoke(this, changes);

            this.IsCompleteLoad = true;
            this.OnCompleteLoad?.Invoke(this);
            return this;
        }

        public Attachment GetAdjunto(string filename)
        {
            return this.Adjuntos?.SingleOrDefault(p => p.Filename == filename);
        }

        private IEnumerable<Changes> SetData(JiraObjs.Issue jira)
        {
            this.Original = jira;

            var changes = new List<Changes>();

            if (this.Status != jira.fields.status.name)
                changes.Add(new Changes("Status", this.Priority, jira.fields.priority.id));

            if (this.Priority != jira.fields.priority.id)
                changes.Add(new Changes("Priority", this.Priority, jira.fields.priority.id));

            if (this.Summary != jira.fields.summary)
                changes.Add(new Changes("Summary", this.Summary, jira.fields.summary));
            
            
            // comments
            var delsc = this.Comments.Where(p => !jira.fields.comment.comments.Select(a => a.id).Contains(p.Id)).Select(p => p.Id);
            var addsc = jira.fields.comment.comments.Where(p => !this.Comments.Select(a => a.Id).Contains(p.id)).Select(a => a.id);

            var updsc = (from c in this.Comments
                         from j in jira.fields.comment.comments
                         where c.Id == j.id && c.ModiFecha != j.updated
                         select new { o = c.Id, n = j.id });

            changes.AddRange(delsc.Select(p => new Changes("Comments", p, null)));
            changes.AddRange(addsc.Select(p => new Changes("Comments", null, p)));
            changes.AddRange(updsc.Select(p => new Changes("Comments", p.o, p.n)));

            // adjuntos
            var dels = this.Adjuntos.Where(p => !jira.fields.attachment.Select(a => a.filename).Contains(p.Filename)).Select(p => p.Filename);
            var adds = jira.fields.attachment.Where(p => !this.Adjuntos.Select(a => a.Filename).Contains(p.filename)).Select(a => a.filename);

            changes.AddRange(dels.Select(p => new Changes("Adjuntos", p, null)));
            changes.AddRange(adds.Select(p => new Changes("Adjuntos", null, p)));


            // Seteo los nuevos valores
            this.Key = jira.key;
            this.Status = jira.fields.status.name;
            this.Priority = jira.fields.priority.id;
            this.Summary = jira.fields.summary;
            this.Comments = jira.fields.comment.comments.Select(p => new Comment(p)).ToList();
            this.Adjuntos = jira.fields.attachment.Select(p => new Attachment(p)).ToList();

            return changes;
        }

        private IEnumerable<Changes> SetData(JiraObjs.Transitions jira)
        {
            var changes = new List<Changes>();

            // transiciones
            this.Transitions = this.Transitions ?? new List<Transition>();
            var dels = this.Transitions.Where(p => !jira.transitions.Select(a => a.id).Contains(p.Id)).Select(p => p.Name);
            var adds = jira.transitions.Where(p => !this.Transitions.Select(a => a.Id).Contains(p.id)).Select(a => a.name);

            changes.AddRange(dels.Select(p => new Changes("Transitions", p, null)));
            changes.AddRange(adds.Select(p => new Changes("Transitions", null, p)));


            // Seteo los nuevos valores
            this.Transitions = jira.transitions.Select(p => new Transition(p)).ToList();

            return changes;
        }

        public override string ToString()
        {
            return $"{this.Key} :: {this.Summary}";
        }
    }
}
