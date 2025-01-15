using AFStudiumAPIClient.Models;
using AFStudiumAPIClient.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AFStudiumAPIClient
{
    public class AFStudiumAPIClientService
    {
        private readonly HttpClient _httpClient;
        public AFStudiumAPIClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:5000");
        }

        public async Task<List<User>?> GetUsers()
        {
            Console.WriteLine(_httpClient.BaseAddress);
            return await _httpClient.GetFromJsonAsync<List<User>?>("/api/User");
        }

        public async Task<User?> GetUserByMatrikelNum(int MatrikelNum)
        {
            return await _httpClient.GetFromJsonAsync<User?>($"/api/User/{MatrikelNum}");
        }

        public async Task<User?> GetUserByEmailNPass(string Email, string Password)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<User?>($"/api/User/{Email},{Password}");
            }
            catch
            {
                return null;
            }          
            
            //return newUser;
        }

        public async Task PostUser(User user)
        {
            await _httpClient.PostAsJsonAsync("/api/User", user);
        }

        public async Task PutUser(User user)
        {
            await _httpClient.PutAsJsonAsync("/api/User", user);
        }
        public async Task DeleteUser(int MatrikelNum)
        {
            await _httpClient.DeleteAsync($"/api/User/{MatrikelNum}");
        }
        /// <summary>
        /// for subjects
        /// </summary>
        /// <returns></returns>

        public async Task<List<Subject>?> GetSubjects()
        {
            Console.WriteLine(_httpClient.BaseAddress);
            return await _httpClient.GetFromJsonAsync<List<Subject>?>("/api/Subject");
        }

        public async Task<Subject?> GetSubjectById(int SubjectId)
        {
            return await _httpClient.GetFromJsonAsync<Subject?>($"/api/Subject/{SubjectId}");
        }

       

        public async Task PostSubject(Subject subject)
        {
            await _httpClient.PostAsJsonAsync("/api/Subject", subject);
        }

        public async Task PutSubject(Subject subject)
        {
            await _httpClient.PutAsJsonAsync("/api/Subject", subject);
        }
        public async Task DeleteSubject(int SubjectId)
        {
            await _httpClient.DeleteAsync($"/api/Subject/{SubjectId}");
        }

        ///for events
        ///
        public async Task<List<Event>?> GetEvents()
        {
            Console.WriteLine(_httpClient.BaseAddress);
            return await _httpClient.GetFromJsonAsync<List<Event>?>("/api/Event");
        }

        public async Task<Event?> GetEventById(int EventId)
        {
            return await _httpClient.GetFromJsonAsync<Event?>($"/api/Event/by-id/{EventId}");
        }

        public async Task<List<Event>?> GetEventsBySubjectId(int SubjectId)
        {
            return await _httpClient.GetFromJsonAsync<List<Event>?>($"/api/Event/by-subjectid/{SubjectId}");
        }
        public async Task<List<Event>?> GetMyEvents(int CreatedPerson)
        {
            return await _httpClient.GetFromJsonAsync<List<Event>?>($"/api/Event/by-createdperson/{CreatedPerson}");
        }
        public async Task PostEvent(Event e)
        {
            await _httpClient.PostAsJsonAsync("/api/Event", e);
        }

        public async Task PutEvent(Event e)
        {
            await _httpClient.PutAsJsonAsync("/api/Event", e);
        }
        public async Task DeleteEvent(int EventId)
        {
            await _httpClient.DeleteAsync($"/api/Event/{EventId}");
        }

        /////for exams
        /////
        //public async Task<List<Exam>?> GetExams()
        //{
        //    Console.WriteLine(_httpClient.BaseAddress);
        //    return await _httpClient.GetFromJsonAsync<List<Exam>?>("/api/Exam");
        //}

        //public async Task<Exam?> GetExamById(int EventId)
        //{
        //    return await _httpClient.GetFromJsonAsync<Exam?>($"/api/Exam/by-id/{EventId}");
        //}

        //public async Task<List<Exam>?> GetExamsBySubjectId(int SubjectId)
        //{
        //    return await _httpClient.GetFromJsonAsync<List<Exam>?>($"/api/Exam/by-subjectid/{SubjectId}");
        //}
        //public async Task<List<Exam>?> GetMyExams(int CreatedPerson)
        //{
        //    return await _httpClient.GetFromJsonAsync<List<Exam>?>($"/api/Exam/by-createdperson/{CreatedPerson}");
        //}
        //public async Task PostExam(Exam e)
        //{
        //    await _httpClient.PostAsJsonAsync("/api/Exam", e);
        //}

        //public async Task PutExam(Exam e)
        //{
        //    await _httpClient.PutAsJsonAsync("/api/Exam", e);
        //}
        //public async Task DeleteExam(int ExamId)
        //{
        //    await _httpClient.DeleteAsync($"/api/Exam/{ExamId}");
        //}

        ///for connections
        ///
        public async Task<List<Connections>?> GetConnections()
        {
            return await _httpClient.GetFromJsonAsync<List<Connections>?>($"/api/Connections");
        }
        public async Task<List<Event>?> GetConnectionsByUserId(int StudentId)
        {
            var list = await _httpClient.GetFromJsonAsync<List<Connections>?>($"/api/Connections/bystudentid/{StudentId}");
            List<Event> events = new List<Event>();
            if (list != null)
            {
                
                foreach (Connections e in list)
                {
                    events.Add(await GetEventById(e.EventId));
                }
            }
            return events;

        }
        public async Task<List<Connections>?> GetConnectionsByEventId(int EventId)
        {
            var list = await _httpClient.GetFromJsonAsync<List<Connections>?>($"/api/Connections/byeventid/{EventId}");
            List<Connections> connections = new List<Connections>();
            if (list != null)
            {

                foreach (Connections e in list)
                {
                    connections.Add(e);
                }
            }
            return connections;

        }

        public async Task PostConnection(int userid, int eventid, bool iscreatororhelper)
        {
            Connections studentsEvents = new Connections() { StudentId = userid, EventId = eventid, IsCreatorOrHelper = iscreatororhelper };
            await _httpClient.PostAsJsonAsync("/api/Connections", studentsEvents);
        }
        public async Task PutConnection(Connections se)
        {
            await _httpClient.PutAsJsonAsync("/api/Connections", se);
        }
        public async Task DeleteConnection(int userid, int eventid)
        {
            Connections? studentsEvents = await _httpClient.GetFromJsonAsync<Connections?>($"/api/Connections/{userid},{eventid}");
            if (studentsEvents != null)
            {
                await _httpClient.DeleteAsync($"/api/Connections/{studentsEvents.Id}");
            }
        }
        
        ///  <summary>
        /// for grades
        /// </summary>
        /// <returns></returns>
    public async Task<List<Grades>?> GetGrades()
    {
        return await _httpClient.GetFromJsonAsync<List<Grades>?>($"/api/Grades");
    }
    public async Task<List<Event>?> GetGradesByUserId(int StudentId)
    {
        var list = await _httpClient.GetFromJsonAsync<List<Grades>?>($"/api/Grades/bystudentid/{StudentId}");
        List<Event> events = new List<Event>();
        if (list != null)
        {

            foreach (Grades e in list)
            {
                events.Add(await GetEventById(e.EventId));
            }
        }
        return events;

    }
    public async Task<List<Grades>?> GetGradesByEventId(int EventId)
    {
        var list = await _httpClient.GetFromJsonAsync<List<Grades>?>($"/api/Grades/byeventid/{EventId}");
        List<Grades> grades = new List<Grades>();
        if (list != null)
        {

            foreach (Grades e in list)
            {
                    grades.Add(e);
            }
        }
        return grades;

    }

    public async Task PostGrades(int userid, int eventid, string grade)
    {
            Grades grades = new Grades() { StudentId = userid, EventId = eventid, Grade = grade };
        await _httpClient.PostAsJsonAsync("/api/Grades", grades);
    }
    public async Task PutGrade(Grades se)
    {
        await _httpClient.PutAsJsonAsync("/api/Grades", se);
    }
    public async Task DeleteGrade(int userid, int eventid)
    {
            Grades? grades = await _httpClient.GetFromJsonAsync<Grades?>($"/api/Grades/{userid},{eventid}");
        if (grades != null)
        {
            await _httpClient.DeleteAsync($"/api/Grades/{grades.Id}");
        }
    }
    /// for messages
    /// 

    public async Task<IEnumerable<Message>?> GetMessages()
        {
            return await _httpClient.GetFromJsonAsync<List<Message>?>("/api/Message");
        }
        public async Task PostMessage(Message message)
        {
            await _httpClient.PostAsJsonAsync("/api/Message", message);
        }
        public async Task PutMessage (Message message)
        {
            await _httpClient.PutAsJsonAsync("/api/Message", message);
        }
        public async Task DeleteMessage(int messageid)
        {
            Message? m = await _httpClient.GetFromJsonAsync<Message?>($"/api/Message/byid/{messageid}");
            if (m != null)
            {
                await _httpClient.DeleteAsync($"/api/Message/byid/{messageid}");
            }
        }
    }
}
