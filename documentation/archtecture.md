# Three Tiers
## Presentation tier:
User interface. Communication Layer. Where the user interacts (the user can be a person, an api, another application).
## Application tier:
Logic tier. Middle tier. Information collected in the [Presentation tier](/archtecture#Presentation tier) is processed - sometimes against other information in the the data tier - using business logic, a specific set of business rules.
- Typically comunicates with the data tier using API calls.

## Data tier:


## Benefits of Three-Tiers:
- Faster development: Because each tier can be developed simultaneously by different teams, an organization can bring the application to market faster, and programmers can use the latest and best languages and tools for each tier.

- Improved scalability: Any tier can be scaled independently of the others as needed.

- Improved reliability: An outage in one tier is less likely to impact the availability or performance of the other tiers.

- Improved security: Because the presentation tier and data tier can't communicate directly, a well-designed application tier can function as a sort of internal firewall, preventing SQL injections and other malicious exploits.