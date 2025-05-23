﻿using MediatR;
using MicroTec.Hr.Domain.Enums;
using MicroTec.Hr.Services.Custodies;

namespace MicroTec.Hr.Services.Employees.CreateEmployee
{
    public record class CreateEmployeeCommand : IRequest<Guid>
    {
        public int EmployeeCode { get; set; }
        public string FullName { get; init; } = default!;
        public DateTimeOffset BirthDate { get; init; }
        public Gender Gender { get; init; }
        public Guid NationalityId { get; init; }
        public Guid UserId { get; init; }
        public IEnumerable<Custody> Custodies { get; init; } = [];
    }
}
