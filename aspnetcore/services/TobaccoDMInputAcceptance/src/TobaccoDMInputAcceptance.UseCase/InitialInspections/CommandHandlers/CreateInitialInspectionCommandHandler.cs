using Dedsi.Ddd.CQRS.CommandHandlers;
using TobaccoDMInputAcceptance.Repositories.InitialInspections;
using TobaccoDMInputAcceptance.InitialInspections.Commands;

namespace TobaccoDMInputAcceptance.InitialInspections.CommandHandlers;

public class CreateInitialInspectionCommandHandler(IInitialInspectionRepository inspectionRepository) : DedsiCommandHandler<CreateInitialInspectionCommand, bool>
{
    public override async Task<bool> Handle(CreateInitialInspectionCommand command, CancellationToken cancellationToken)
    {
        var initialInspection = new InitialInspection(GuidGenerator.Create(), command.InitialName, command.InitialDescription, command.InitialInspector);

        initialInspection.AddTobaccoGrowerAndSetInitialInspectionId(command.TobaccoGrowers);

        await inspectionRepository.InsertAsync(initialInspection,false, cancellationToken);
        
        return true;
    }
}